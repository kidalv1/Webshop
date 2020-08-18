using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Syncfusion.Pdf.Grid;
using Webshop.BL;
using Webshop.UI_MVC.Models;
using Webshop.UI_MVC.Models.Webshop;

namespace Webshop.UI_MVC.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult Index()
        {
            bool loggedIn = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (loggedIn == true)
            {
                return View();
            }
            else return RedirectToAction("Login", "Account");
        }


        //POST: Purchase
        [HttpPost]
        public ActionResult Index(List<ShoppingCart> cart)
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            Invoice invoice = new Invoice(DateTime.Today, false, false, DateTime.Now.ToString(), user.Email, user.Surname, user.Firstname);
            APIConsumer<Models.Webshop.Invoice>.AddObject("invoice", invoice);

            Webshop.BL.EmailService service = new Webshop.BL.EmailService();
            PdfDocument doc = new PdfDocument();
            //Add a page
            PdfPage page = doc.Pages.Add();

            //Create border color.
            PdfColor borderColor = new PdfColor(Color.FromArgb(255, 142, 170, 219));
            PdfBrush lightBlueBrush = new PdfSolidBrush(new PdfColor(Color.FromArgb(255, 91, 126, 215)));

            PdfBrush darkBlueBrush = new PdfSolidBrush(new PdfColor(Color.FromArgb(255, 65, 104, 209)));

            PdfBrush whiteBrush = new PdfSolidBrush(new PdfColor(Color.FromArgb(255, 255, 255, 255)));
            PdfPen borderPen = new PdfPen(borderColor, 1f);

            //Create TrueType font.
            PdfTrueTypeFont headerFont =
                new PdfTrueTypeFont(new Font("Arial", 30, System.Drawing.FontStyle.Regular), true);
            PdfTrueTypeFont arialRegularFont =
                new PdfTrueTypeFont(new Font("Arial", 9, System.Drawing.FontStyle.Regular), true);
            PdfTrueTypeFont arialBoldFont =
                new PdfTrueTypeFont(new Font("Arial", 11, System.Drawing.FontStyle.Bold), true);

            const float margin = 30;
            const float lineSpace = 7;
            const float headerHeight = 90;

            //Add Ghrapics
            PdfGraphics graphics = page.Graphics;

            //Get the page width and height.
            float pageWidth = page.GetClientSize().Width;
            float pageHeight = page.GetClientSize().Height;
            //Draw page border
            graphics.DrawRectangle(borderPen, new RectangleF(0, 0, pageWidth, pageHeight));

            //Fill the header with light Brush.
            graphics.DrawRectangle(lightBlueBrush, new RectangleF(0, 0, pageWidth, headerHeight));

            RectangleF headerAmountBounds = new RectangleF(400, 0, pageWidth - 400, headerHeight);

            graphics.DrawString("Bestelbon", headerFont, whiteBrush, new PointF(margin, headerAmountBounds.Height / 3));

            graphics.DrawRectangle(darkBlueBrush, headerAmountBounds);

            graphics.DrawString("Totaal te betalen", arialRegularFont, whiteBrush, headerAmountBounds,
                new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle));

            List<Invoice> invoices = APIConsumer<Invoice>.GetAPI("invoice").ToList();

            PdfTextElement textElement = new PdfTextElement("Factuurnr.: " + invoices.Count, arialRegularFont);

            PdfLayoutResult layoutResult = textElement.Draw(page, new PointF(headerAmountBounds.X - margin, 120));

            textElement.Text = "Datum : " + DateTime.Now.ToString("dd MMMM yyyy");
            textElement.Draw(page, new PointF(layoutResult.Bounds.X, layoutResult.Bounds.Bottom + lineSpace));

            textElement.Text = "Aan:";
            layoutResult = textElement.Draw(page, new PointF(margin, 120));

            textElement.Text = user.Firstname + " " + user.Surname;
            layoutResult = textElement.Draw(page, new PointF(margin, layoutResult.Bounds.Bottom + lineSpace));
            textElement.Text = user.Address + " , Postcode: " + user.ZIPCode;
            layoutResult = textElement.Draw(page, new PointF(margin, layoutResult.Bounds.Bottom + lineSpace));
            textElement.Text = user.PhoneNumber;
            layoutResult = textElement.Draw(page, new PointF(margin, layoutResult.Bounds.Bottom + lineSpace));
            textElement.Text = user.Email;
            layoutResult = textElement.Draw(page, new PointF(margin, layoutResult.Bounds.Bottom + lineSpace));

            PdfGrid grid = new PdfGrid();

            DataTable dataTable = new DataTable();
            ////Add columns to the DataTable
            dataTable.Columns.Add("Product");
            dataTable.Columns.Add("Aantal");
            dataTable.Columns.Add("Prijs");

            ////Add rows to the DataTable
            cart = (List<ShoppingCart>) Session["cart"];
            foreach (ShoppingCart item in (List<ShoppingCart>) Session["cart"])
            {
                if (item.Course == null)
                {
                    dataTable.Rows.Add(new object[]
                        {item.Product.Name, item.Quantity, (item.Product.Price * item.Quantity)});
                }
                else
                {
                    dataTable.Rows.Add(new object[]
                        {item.Course.Name, item.Quantity, (item.Course.Price * item.Quantity)});
                }
            }

            grid.DataSource = dataTable;

            grid.Columns[1].Width = 150;
            grid.Style.Font = arialRegularFont;
            grid.Style.CellPadding.All = 5;

            grid.ApplyBuiltinStyle(PdfGridBuiltinStyle.ListTable4Accent5);

            layoutResult = grid.Draw(page, new PointF(0, layoutResult.Bounds.Bottom + 40));

            textElement.Text = "Totaal: ";
            textElement.Font = arialBoldFont;
            layoutResult = textElement.Draw(page,
                new PointF(headerAmountBounds.X - 40, layoutResult.Bounds.Bottom + lineSpace));

            float totalAmountCourses = (float) cart.Where(item => item.Course != null).Sum(item => item.Course.Price * item.Quantity);
            float totalAmountProducts = (float)cart.Where(item => item.Product != null).Sum(item => item.Product.Price * item.Quantity);
            float totalAmount = totalAmountProducts + totalAmountCourses;
            textElement.Text = "€" + totalAmount.ToString();
            layoutResult = textElement.Draw(page, new PointF(layoutResult.Bounds.Right + 4, layoutResult.Bounds.Y));

            graphics.DrawString("€" + totalAmount.ToString(), arialBoldFont, whiteBrush,
                new RectangleF(400, lineSpace, pageWidth - 400, headerHeight + 15),
                new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle));

            borderPen.DashStyle = PdfDashStyle.Custom;
            borderPen.DashPattern = new float[] {3, 3};

            PdfLine line = new PdfLine(borderPen, new PointF(0, 0), new PointF(pageWidth, 0));
            layoutResult = line.Draw(page, new PointF(0, pageHeight - 100));

            textElement.Text = "dotNET academy Antwerpen";
            textElement.Font = arialRegularFont;
            layoutResult = textElement.Draw(page, new PointF(margin, layoutResult.Bounds.Bottom + (lineSpace * 3)));
            textElement.Text = "Komiteitstraat 46-52 (de Koekenfabriek), 2170 Antwerpen";
            layoutResult = textElement.Draw(page, new PointF(margin, layoutResult.Bounds.Bottom + lineSpace));
            textElement.Text = "Vragen? \n tel: +32 16 35 93 78 \n email: info@dotnetacademy.be";
            layoutResult = textElement.Draw(page, new PointF(margin, layoutResult.Bounds.Bottom + lineSpace));

            //Save the document
            doc.Save(@"\Invoices\Bestelling.pdf");
            //Close the document
            doc.Close(true);


            foreach (ShoppingCart item in cart)
            {
                if (item.Course == null)
                {
                    InvoiceDetail detail = new InvoiceDetail(item.Quantity, 0, item.Product.Id);
                    APIConsumer<Models.Webshop.InvoiceDetail>.AddObject("InvoiceDetail", detail);
                }
                else
                {
                    InvoiceDetail detail = new InvoiceDetail(item.Quantity, item.Course.Id);
                    APIConsumer<Models.Webshop.InvoiceDetail>.AddObject("InvoiceDetail", detail);
                }
            }

            string mail = user.Email;
            service.SendInvoice(mail, "Factuur", "Als bijlage uw bestelbon.");

            return RedirectToAction("Success", "Purchase");
        }

        // GET: Purchase/Success
        public ActionResult Success()
        {
            Session.Clear();
            return View();
        }
    }
}