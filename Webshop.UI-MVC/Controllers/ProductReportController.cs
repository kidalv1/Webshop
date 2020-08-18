using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Webshop.UI_MVC.Models.Webshop;

namespace Webshop.UI_MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductReportController : Controller
    {
        IEnumerable<Product> products = APIConsumer<Product>.GetAPI("product");
        IEnumerable<InvoiceDetail> details = APIConsumer<InvoiceDetail>.GetAPI("invoicedetail");
        List<int> aantalList = new List<int>();

        // GET: ProductReport
        public ActionResult Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var result = products.Where(
                    s => s.Name.ToLower().Contains(searchString) || s.Name.Contains(searchString)
                );
                foreach (Product product in result)
                {
                    var aantal = 0;
                    foreach (InvoiceDetail item in details)
                    {
                        if (item.ProductId != 0)
                        {
                            if (product.Id == item.ProductId)
                            {
                                aantal += item.Pieces;
                            }
                        }
                    }
                    aantalList.Add(aantal);
                }

                ViewBag.aantalList = aantalList;
                return View(result);
            }

            foreach (Product product in products)
            {
                var aantal = 0;
                foreach (InvoiceDetail item in details)
                {
                    if (item.ProductId != 0)
                    {
                        if (product.Id == item.ProductId)
                        {
                            aantal += item.Pieces;
                        }
                    }
                }
                aantalList.Add(aantal);
            }

            ViewBag.aantalList = aantalList;
            return View(products);
        }

        public ActionResult Details(int id)
        {
            return RedirectToAction("Details", "Product", new {id});
        }
    }
}