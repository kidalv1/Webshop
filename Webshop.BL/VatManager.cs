using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.DAL.Entit;
using Webshop.DAL.Repositories;

namespace Webshop.BL
{
    public class VatManager : IManager<Vat>
    {
        private VatRepo repo;

        public VatManager()
        {
            repo = new VatRepo();
        }

        public void Add(Vat t)
        {
            repo.Create(t);
        }

        public Vat FindById(int? id)
        {
            return repo.Read(id);
        }

        public void Modify()
        {
            repo.Update();
        }

        public List<Vat> GetAll()
        {
            return repo.ReadAll();
        }

        public void Remove(Vat t)
        {
            repo.Delete(t);
        }
    }
}
