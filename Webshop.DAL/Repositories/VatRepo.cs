using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.UI.WebControls;
using Webshop.DAL.Entit;

namespace Webshop.DAL.Repositories
{
    public class VatRepo : IRepository<Vat>
    {
        private WebshopContext _webshopContext;
        public VatRepo(WebshopContext context)
        {
            _webshopContext = context;
        }

        public Vat Add(Vat t)
        {
            try
            {
                _webshopContext._Vats.Add(t);
                return t;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
           
          
        }

        public Vat FindById(int? id)
        {
            try
            {
                return _webshopContext._Vats.Find(id);
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public Vat Modify(Vat vat)
        {
            try
            {
                _webshopContext._Vats.AddOrUpdate(vat);
                return vat;
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
           
        }

        public List<Vat> GetAll()
        {
            try
            {
                return _webshopContext._Vats.ToList();
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public void Remove(Vat t)
        {

            try
            {
                var vat = FindById(t.Id);
                _webshopContext._Vats.Remove(vat);
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }
    }
}
