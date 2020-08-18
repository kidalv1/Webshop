using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.DAL.Entit;
using Webshop.DAL.Repositories;

namespace Webshop.BL
{
    public class InvoiceDetailManager : IManager<InvoiceDetail>
    {
        private InvoiceDetailRepo repo;

        public InvoiceDetailManager()
        {
            repo = new InvoiceDetailRepo();
        }

        public void Add(InvoiceDetail t)
        {
            repo.Create(t);
        }

        public InvoiceDetail FindById(int? id)
        {
            return repo.Read(id);
        }

        public void Modify()
        {
            repo.Update();
        }

        public List<InvoiceDetail> GetAll()
        {
            return repo.ReadAll();
        }

        public void Remove(InvoiceDetail t)
        {
            repo.Delete(t);
        }
    }
}
