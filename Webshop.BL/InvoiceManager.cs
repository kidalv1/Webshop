using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.DAL.Entit;
using Webshop.DAL.Repositories;

namespace Webshop.BL
{
    public class InvoiceManager : IManager<Invoice>
    {
        private InvoiceRepo repo;

        public InvoiceManager()
        {
            repo = new InvoiceRepo();
        }

        public void Add(Invoice t)
        {
            repo.Create(t);
        }

        public Invoice FindById(int? id)
        {
            return repo.Read(id);
        }

        public void Modify()
        {
            repo.Update();
        }

        public List<Invoice> GetAll()
        {
            return repo.GetAll();
        }

        public void Remove(Invoice t)
        {
            repo.Delete(t);
        }
    }
}
