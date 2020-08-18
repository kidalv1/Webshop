using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.DAL.Entit;
using Webshop.DAL.Repositories;

namespace Webshop.BL
{
    class ProductPriceManager : IManager<ProductPrice>
    {
        private ProductPriceRepo repo;

        public ProductPriceManager()
        {
            repo = new ProductPriceRepo();
        }

        public void Add(ProductPrice t)
        {
            repo.Create(t);
        }

        public ProductPrice FindById(int? id)
        {
            return repo.Read(id);
        }

        public void Modify()
        {
            repo.Update();
        }

        public List<ProductPrice> GetAll()
        {
            return repo.ReadAll();
        }

        public void Remove(ProductPrice t)
        {
            repo.Delete(t);
        }
    }
}
