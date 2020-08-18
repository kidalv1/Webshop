using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.UI_MVC.Models.Webshop;

namespace Webshop.UI_MVC.Controllers
{
    public class InvoiceDetailController : Controller
    {
        private const string PATH = "invoicedetail";
        private IEnumerable<InvoiceDetail> invoiceDetails = APIConsumer<InvoiceDetail>.GetAPI("invoicedetail");

        // GET: InvoiceDetail
        public ActionResult Index()
        {
            return View(invoiceDetails);
        }

        // GET: InvoiceDetail/Details/5
        public ActionResult Details(int id)
        {
            return View(APIConsumer<InvoiceDetail>.GetObject(PATH, id.ToString()));
        }

        // GET: InvoiceDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceDetail/Create
        [HttpPost]
        public ActionResult Create(InvoiceDetail invoiceDetail)
        {
            try
            {
                // TODO: Add insert logic here
                APIConsumer<Models.Webshop.InvoiceDetail>.AddObject(PATH, invoiceDetail);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: InvoiceDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View(APIConsumer<InvoiceDetail>.GetObject(PATH, id.ToString()));
        }

        // POST: InvoiceDetail/Edit/5
        [HttpPost]
        public ActionResult Edit(InvoiceDetail invoiceDetail)
        {
            try
            {
                // TODO: Add update logic here
                APIConsumer<Models.Webshop.InvoiceDetail>.EditObject(PATH, invoiceDetail.Id.ToString(), invoiceDetail);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: InvoiceDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View(APIConsumer<InvoiceDetail>.GetObject(PATH, id.ToString()));
        }

        // POST: InvoiceDetail/Delete/5
        [HttpPost]
        public ActionResult Delete(InvoiceDetail invoiceDetail)
        {
            try
            {
                // TODO: Add delete logic here
                APIConsumer<Models.Webshop.InvoiceDetail>.DeleteObject(PATH, (invoiceDetail.Id).ToString(), invoiceDetail);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
