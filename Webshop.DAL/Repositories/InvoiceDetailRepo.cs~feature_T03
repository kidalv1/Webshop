using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.DAL.Entit;

namespace Webshop.DAL.Repositories
{
    public class InvoiceDetailRepo : IRepository<InvoiceDetail>
    {
        private WebshopContext _webshopContext = new WebshopContext();
        public void Add(InvoiceDetail t)
        {
            _webshopContext._InvoiceDetails.Add(t);
            _webshopContext.SaveChanges();
        }

        public InvoiceDetail FindById(int? id)
        {
            return _webshopContext._InvoiceDetails.Find(id);
        }

        public void Modify(InvoiceDetail t)
        {
            _webshopContext._InvoiceDetails.AddOrUpdate(t);
        }

        public List<InvoiceDetail> GetAll()
        {
            return _webshopContext._InvoiceDetails.ToList();
        }

        public void Remove(InvoiceDetail t)
        {
            _webshopContext._InvoiceDetails.Remove(t);
            _webshopContext.SaveChanges();
        }
    }
}
