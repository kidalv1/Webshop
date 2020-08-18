using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.UI_MVC.Models.Webshop;

namespace Webshop.UI_MVC.Controllers
{
    public class ProductPriceController : Controller
    {
        private const string PATH = "productprice";
        private IEnumerable<ProductPrice> productPrices = APIConsumer<ProductPrice>.GetAPI("productprice");
        // GET: ProductPrice
        public ActionResult Index()
        {
            return View(productPrices);
        }

        // GET: ProductPrice/Details/5
        public ActionResult Details(int id)
        {
            return View(APIConsumer<ProductPrice>.GetObject(PATH, id.ToString()));
        }

        // GET: ProductPrice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductPrice/Create
        [HttpPost]
        public ActionResult Create(ProductPrice productPrice)
        {
           try
            {
                // TODO: Add insert logic here
                APIConsumer<Models.Webshop.ProductPrice>.AddObject(PATH, productPrice);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductPrice/Edit/5
        public ActionResult Edit(int id)
        {
            return View(APIConsumer<ProductPrice>.GetObject(PATH, id.ToString()));
        }

        // POST: ProductPrice/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductPrice productPrice)
        {
            try
            {
                // TODO: Add update logic here
                APIConsumer<Models.Webshop.ProductPrice>.EditObject(PATH, productPrice.Id.ToString(), productPrice);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductPrice/Delete/5
        public ActionResult Delete(int id)
        {
            return View(APIConsumer<ProductPrice>.GetObject(PATH, id.ToString()));
        }

        // POST: ProductPrice/Delete/5
        [HttpPost]
        public ActionResult Delete(ProductPrice productPrice)
        {
            try
            {
                // TODO: Add delete logic here
                APIConsumer<Models.Webshop.ProductPrice>.DeleteObject(PATH, (productPrice.Id).ToString(), productPrice);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
