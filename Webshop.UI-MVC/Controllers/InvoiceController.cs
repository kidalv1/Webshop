using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.UI_MVC.Models.Webshop;

namespace Webshop.UI_MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InvoiceController : Controller
    {
        private const string PATH = "invoice";
        private IEnumerable<Invoice> invoices = APIConsumer<Invoice>.GetAPI("invoice");

        // GET: Invoice
        public ActionResult Index(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                List<Invoice> activeInvoices = new List<Invoice>();
                foreach (Invoice item in invoices)
                {
                    if (item.Surname != null && item.Firstname != null)
                    {
                        if ((search.ToLower() == item.Surname.ToLower() ||
                             search.ToLower() == item.Firstname.ToLower()) && item.Deleted == false)
                        {
                            activeInvoices.Add(item);
                        }
                    }
                }

                return View(activeInvoices);
            }

            return View(invoices.Where(x => x.Deleted != true));
        }

        public ActionResult DeletedIndex(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                List<Invoice> deletedInvoices = new List<Invoice>();
                foreach (Invoice item in invoices)
                {
                    if (item.Surname != null && item.Firstname != null)
                    {
                        if ((search.ToLower() == item.Surname.ToLower() ||
                             search.ToLower() == item.Firstname.ToLower()) && item.Deleted == true)
                        {
                            deletedInvoices.Add(item);
                        }
                    }
                }

                return View(deletedInvoices);
            }

            return View(invoices.Where(x => x.Deleted == true));
        }

        // GET: Invoice/Details/5
        public ActionResult Details(int id)
        {
            return View(APIConsumer<Invoice>.GetObject(PATH, id.ToString()));
        }

        // GET: Invoice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invoice/Create
        [HttpPost]
        public ActionResult Create(Invoice invoice)
        {
            try
            {
                // TODO: Add insert logic here
                APIConsumer<Models.Webshop.Invoice>.AddObject(PATH, invoice);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Invoice/Edit/5
        public ActionResult Edit(int id)
        {
            Invoice invoice = APIConsumer<Invoice>.GetObject(PATH, id.ToString());
            string email = invoice.Email;
            string surname = invoice.Surname;

            string firstname = invoice.Firstname;
            if (invoice.Deleted == false)
            {
                invoice.Email = email;
                invoice.Surname = surname;
                invoice.Firstname = firstname;
                return View(invoice);
            }

            else return RedirectToAction("DeletedIndex");
        }

        // POST: Invoice/Edit/5
        [HttpPost]
        public ActionResult Edit(Invoice invoice)
        {
            try
            {
                // TODO: Add update logic here
                invoice = APIConsumer<Invoice>.GetObject(PATH, invoice.Id.ToString());

                if (invoice.IsPaid == false)
                {
                    invoice.IsPaid = true;
                }
                else invoice.IsPaid = false;

                APIConsumer<Models.Webshop.Invoice>.EditObject(PATH, invoice.Id.ToString(), invoice);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Invoice/Delete/5
        public ActionResult Delete(int id)
        {
            Invoice invoice = APIConsumer<Invoice>.GetObject(PATH, id.ToString());
            if (invoice.Deleted == false)
            {
                return View(invoice);
            }

            else return RedirectToAction("DeletedIndex");
        }

        // POST: Invoice/Delete/5
        [HttpPost]
        public ActionResult Delete(Invoice invoice)
        {
            try
            {
                // TODO: Add delete logic here
                invoice = APIConsumer<Invoice>.GetObject(PATH, (invoice.Id).ToString());
                invoice.Deleted = true;
                APIConsumer<Models.Webshop.Invoice>.EditObject(PATH, invoice.Id.ToString(), invoice);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}