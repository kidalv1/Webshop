using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.UI_MVC.Models.Webshop;

namespace Webshop.UI_MVC.Controllers
{
    public class VatController : Controller
    {
        private const string PATH = "vat";
        private IEnumerable<Vat> vats = APIConsumer<Vat>.GetAPI("vat");

        // GET: Vat
        public ActionResult Index()
        {
            return View(vats);
        }

        // GET: Vat/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            return View(APIConsumer<Vat>.GetObject(PATH, id.ToString()));
        }

        // GET: Vat/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vat/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Vat vat)
        {
            try
            {
                // TODO: Add insert logic here
                APIConsumer<Models.Webshop.Vat>.AddObject(PATH, vat);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vat/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View(APIConsumer<Vat>.GetObject(PATH, id.ToString()));
        }

        // POST: Vat/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Vat vat)
        {
            try
            {
                // TODO: Add update logic here
                APIConsumer<Models.Webshop.Vat>.EditObject(PATH, vat.Id.ToString(), vat);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vat/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View(APIConsumer<Vat>.GetObject(PATH, id.ToString()));
        }

        // POST: Vat/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Vat vat)
        {
            try
            {
                // TODO: Add delete logic here
                APIConsumer<Models.Webshop.Vat>.DeleteObject(PATH, (vat.Id).ToString(), vat);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
