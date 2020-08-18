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
    public class VatLogic : ILogic<VatDTO>
    {
        private UnitOfWork _uow;
        private static readonly log4net.ILog log = log4net.LogManager
            .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public VatLogic(UnitOfWork uow)
        {
            _uow = uow;
        }

        public VatDTO Create(VatDTO c)
        {
            try
            {
                var vat = MapDTO.Map<Vat, VatDTO>(c);
                _uow.VatRepo.Add(vat);
                _uow.Save();

                c.Id = vat.Id;

                return c;
            }
            catch (Exception e)
            {
               log.Error(e.Message);
               throw new Exception(e.Message);
            }
            
        }

        public VatDTO FindByID(int? id)
        {
            try
            {
                var c = _uow.VatRepo.FindById(id);
                return c == null ? null : MapDTO.Map<VatDTO, Vat>(c);
            }
            catch (Exception e)
            {
               log.Error("kon geen btw id vinden",e);
               throw new Exception(e.Message);
            }
        }

        public void Delete(VatDTO c)
        {
            try
            {
                _uow.VatRepo.Remove(MapDTO.Map<Vat, VatDTO>(c));
                _uow.Save();
            }
            catch (Exception e)
            {
                log.Error("kon geen btw verwijderen",e);
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            var c = FindByID(id);
            try
            {
                _uow.VatRepo.Remove(MapDTO.Map<Vat, VatDTO>(c));
                _uow.Save();
            }
            catch (Exception e)
            {
                log.Error("kon geen btw verwijderren", e);
                throw new Exception(e.Message);
            }
        }

        public List<VatDTO> GetAll()
        {
            try
            {
                return MapDTO.MapList<VatDTO, Vat>(_uow.VatRepo.GetAll());
            }
            catch (Exception e)
            {
               log.Error("kon geen btw's vinden",e);
                throw new Exception(e.Message);
            }
        }

        public VatDTO Update(VatDTO c)
        {
            try
            {
                _uow.VatRepo.Modify(MapDTO.Map<Vat, VatDTO>(c));
                _uow.Save();
                return c;
            }
            catch (Exception e)
            {
                log.Error("kon geen btw aanpassen",e);
                throw new Exception(e.Message);
            }
        }
    }
}

