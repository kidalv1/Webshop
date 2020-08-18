using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Webshop.DAL.Entit;

namespace Webshop.DAL.Repositories
{
    public class ProductRepo : IRepository<Product>
    {
        private WebshopContext _webshopContext;
        public ProductRepo(WebshopContext context)
        {
            _webshopContext = context;
        }

        public Product Add(Product t)
        {
            try
            {
                _webshopContext._Products.Add(t);
                return t;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
            
         
        }

        public Product FindById(int? id)
        {
            try
            {
                return _webshopContext._Products.Find(id);
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public Product Modify(Product product)
        {
            try
            {
                _webshopContext._Products.AddOrUpdate(product);
                return product;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
           
        }

        public List<Product> GetAll()
        {
            return _webshopContext._Products.ToList();
        }

        public void Remove(Product t)
        {
            try
            {
                var product = FindById(t.Id);
                _webshopContext._Products.Remove(product);
            }
            catch (Exception e)
            {
                
                throw new  Exception(e.Message);
            }

        }
    }
}
