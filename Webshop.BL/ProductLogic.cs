using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using AutoMapper;
using Webshop.DAL;
using Webshop.DAL.Entit;
using Webshop.DAL.Repositories;
using Webshop.DAL.UnitOfWork;
using Webshop.Domain;

namespace Webshop.BL
{
    public class ProductLogic : ILogic<ProductDTO>
    {
        private UnitOfWork _uow;

        private static readonly log4net.ILog log = log4net.LogManager
            .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private ProductPriceLogic _prdPriceLogic;

        public ProductLogic(UnitOfWork uow)
        {
            _uow = uow;
            _prdPriceLogic = new ProductPriceLogic(uow);
        }

        public ProductDTO Create(ProductDTO c)
        {
            try
            {
                var product = MapDTO.Map<Product, ProductDTO>(c);
                ProductPriceDTO price = _prdPriceLogic.GetAll().Last();
                product.PriceId = price.Id;
                _uow.ProductRepo.Add(product);
                _uow.Save();

                c.Id = product.Id;

                return c;
            }
            catch (Exception e)
            {
                log.Error("kon geen product toevoegen",e);
                throw  new Exception(e.Message);
            }
        }

        public ProductDTO FindByID(int? id)
        {
            try
            {
                var c = _uow.ProductRepo.FindById(id);

                return c == null ? null : MapDTO.Map<ProductDTO, Product>(c);
            }
            catch (Exception e)
            {
                log.Error("kon geen product vinden");
                throw new Exception(e.Message);
            }
        }

        public void Delete(ProductDTO c)
        {
            try
            {
                _uow.ProductRepo.Remove(MapDTO.Map<Product, ProductDTO>(c));
                _uow.Save();
            }
            catch (Exception e)
            {
                log.Error("kon geen product verwijderen");
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            var c = FindByID(id);
            try
            {
                _uow.ProductRepo.Remove(MapDTO.Map<Product, ProductDTO>(c));
                _uow.Save();
            }
            catch (Exception e)
            {
                log.Error("kon geen product verwijderren", e);
                throw new Exception(e.Message);
            }
        }

        public List<ProductDTO> GetAll()
        {
            try
            {
                return MapDTO.MapList<ProductDTO, Product>(_uow.ProductRepo.GetAll());
            }
            catch (Exception e)
            {
                log.Error("kon geen producten oplijsten");
                throw new Exception(e.Message);
            }
        }

        public ProductDTO Update(ProductDTO c)
        {
            try
            {
                _uow.ProductRepo.Modify(MapDTO.Map<Product, ProductDTO>(c));
                _uow.Save();
                return c;
            }
            catch (Exception e)
            {
                log.Error("kon geen product wijzigen");
                throw new Exception(e.Message);
            }
        }
    }
}
