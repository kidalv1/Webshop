using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Webshop.DAL;
using Webshop.DAL.Entit;
using Webshop.DAL.Repositories;
using Webshop.DAL.UnitOfWork;
using Webshop.Domain;

namespace Webshop.BL
{
    public class ProductPriceLogic : ILogic<ProductPriceDTO>
    {
        private UnitOfWork _uow;
        private static readonly log4net.ILog log = log4net.LogManager
            .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ProductPriceLogic(UnitOfWork uow)
        {
            _uow = uow;
        }

        public ProductPriceDTO Create(ProductPriceDTO c)
        {
            try
            {
                var productPrice = MapDTO.Map<ProductPrice, ProductPriceDTO>(c);
                _uow.ProductPriceRepo.Add(productPrice);
                _uow.Save();

                c.Id = productPrice.Id;

                return c;
            }
            catch (Exception e)
            {
                log.Error("kon geen productprijs toevoegen");
                throw new Exception(e.Message);
            }
        }

        public ProductPriceDTO FindByID(int? id)
        {
            try
            {
                var c = _uow.ProductPriceRepo.FindById(id);
                return c == null ? null : MapDTO.Map<ProductPriceDTO, ProductPrice>(c);
            }
            catch (Exception e)
            {
                log.Error("kon geen Prijs id vinden");
                throw new Exception(e.Message);
            }
        }

        public void Delete(ProductPriceDTO c)
        {
            try
            {
                _uow.ProductPriceRepo.Remove(MapDTO.Map<ProductPrice, ProductPriceDTO>(c));
                _uow.Save();
            }
            catch (Exception e)
            {
                log.Error("kon geen prijs verwijderen",e);
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            var c = FindByID(id);
            try
            {
                _uow.ProductPriceRepo.Remove(MapDTO.Map<ProductPrice, ProductPriceDTO>(c));
                _uow.Save();
            }
            catch (Exception e)
            {
                log.Error("kon geen prijs verwijderren", e);
                throw new Exception(e.Message);
            }
        }

        public List<ProductPriceDTO> GetAll()
        {
            try
            {
                return MapDTO.MapList<ProductPriceDTO, ProductPrice>(_uow.ProductPriceRepo.GetAll());
            }
            catch (Exception e)
            {
                log.Error("kon geen producten ophalen",e);
                throw new Exception(e.Message);
            }
        }

        public ProductPriceDTO Update(ProductPriceDTO c)
        {
            try
            {
                _uow.ProductPriceRepo.Modify(MapDTO.Map<ProductPrice, ProductPriceDTO>(c));
                _uow.Save();
                return c;
            }
            catch (Exception e)
            {
               log.Error("kon geen prijs aanpassen",e);
               throw new Exception(e.Message);
            }
        }
    }
}

