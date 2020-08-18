using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Webshop.UI_MVC.Models;
using Webshop.UI_MVC.Models.Webshop;

namespace Webshop.UI_MVC.Controllers
{
    public class MyOrderController : Controller
    {
        private IEnumerable<Invoice> invoices;
        private IEnumerable<InvoiceDetail> details;
        private List<Invoice> activeInvoices;
        private List<ShoppingCart> orderDetails;

        private ApplicationUser user;

        public MyOrderController()
        {
            invoices = APIConsumer<Invoice>.GetAPI("invoice");
            details = APIConsumer<InvoiceDetail>.GetAPI("invoicedetail");
            activeInvoices = new List<Invoice>();
            user = System.Web.HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
        }

        // GET: MyOrder
        public ActionResult Index()
        {
            foreach (Invoice item in invoices)
            {
                if (item.Email == user.Email)
                {
                    activeInvoices.Add(item);
                }
            }

            return View(activeInvoices);
        }

        // GET: MyOrder
        public ActionResult Details(int id)
        {
            orderDetails = new List<ShoppingCart>();
            decimal total = 0;

            foreach (Invoice item in invoices)
            {
                if (item.Email == user.Email)
                {
                    foreach (InvoiceDetail detail in details)
                    {
                        if (detail.InvoiceId == id)
                        {
                            if (detail.ProductId != 0)
                            {
                                Product products =
                                    APIConsumer<Product>.GetObject("product", detail.ProductId.ToString());
                                total += (products.Price * detail.Pieces);
                                orderDetails.Add(new ShoppingCart() {Product = products, Quantity = detail.Pieces});
                            }

                            if (detail.CourseId != 0)
                            {
                                Course courses = APIConsumer<Course>.GetObject("course", detail.CourseId.ToString());
                                total += (courses.Price * detail.Pieces);
                                orderDetails.Add(new ShoppingCart() {Course = courses, Quantity = detail.Pieces});
                            }
                        }
                    }

                    ViewBag.total = total;
                    break;
                }
            }

            return View(orderDetails);
        }
    }
}