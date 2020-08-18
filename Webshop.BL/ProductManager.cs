using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.DAL.Entit;
using Webshop.DAL.Repositories;

namespace Webshop.BL
{
    public class ProductManager : IManager<Product>
    {
        private ProductRepo repo;

        public ProductManager()
        {
            repo = new ProductRepo();
        }

        public void Add(Product t)
        {
            repo.Create(t);
        }

        public Product FindById(int? id)
        {
            return repo.Read(id);
        }

        public void Modify()
        {
            repo.Update();
        }

        public List<Product> GetAll()
        {
            return repo.ReadAll();
        }

        public void Remove(Product t)
        {
            repo.Delete(t);
        }
    }
}
