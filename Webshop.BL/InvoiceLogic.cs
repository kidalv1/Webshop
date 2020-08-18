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
    public class InvoiceLogic : ILogic<InvoiceDTO>
    {
        private UnitOfWork _uow;
        private static readonly log4net.ILog log = log4net.LogManager
            .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static int counter;
        private DateTime today = DateTime.Today;

        private DateTime firstDayOfNextMonth = new DateTime(DateTime.Today.Year + (DateTime.Today.Month) / 12,
            (DateTime.Today.Month) % 12 + 1, 1);

        public InvoiceLogic(UnitOfWork uow)
        {
            _uow = uow;
        }

        public InvoiceDTO Create(InvoiceDTO c)
        {
            try
            {
                if (today != firstDayOfNextMonth)
                {
                    counter++;

                    var now = DateTime.Now;
                    var generateId = now.Year + "-" + now.Month + "-" + counter;
                    var invoiceRepo = MapDTO.Map<Invoice, InvoiceDTO>(c);
                    invoiceRepo.InvoiceCode = generateId;
                    _uow.InvoiceRepo.Add(invoiceRepo);
                    _uow.Save();

                    c.Id = invoiceRepo.Id;
                }
                else
                {
                    getCounter();
                    var now = DateTime.Now;
                    var generateId = now.Year + "-" + now.Month + "-" + counter;

                    var invoiceRepo = MapDTO.Map<Invoice, InvoiceDTO>(c);
                    invoiceRepo.InvoiceCode = generateId;
                    _uow.InvoiceRepo.Add(invoiceRepo);
                    _uow.Save();

                    c.InvoiceCode = generateId;
                    c.Id = invoiceRepo.Id;
                }

                return c;
            }
            catch (Exception e)
            {
                log.Error("kon geen factuur toevoegen",e);
                throw new Exception(e.Message);
            }
        }

        public InvoiceDTO FindByID(int? id)
        {
            var c = _uow.InvoiceRepo.FindById(id);

            return c == null ? null : MapDTO.Map<InvoiceDTO, Invoice>(c);
        }

        public void Delete(InvoiceDTO c)
        {
            _uow.InvoiceRepo.Remove(MapDTO.Map<Invoice, InvoiceDTO>(c));
            _uow.Save();
        }

        public void Delete(int id)
        {
            var c = FindByID(id);
            try
            {
                _uow.InvoiceRepo.Remove(MapDTO.Map<Invoice, InvoiceDTO>(c));
                _uow.Save();
            }
            catch (Exception e)
            {
                log.Error("kon geen invoice verwijderren", e);
                throw new Exception(e.Message);
            }
        }

        public List<InvoiceDTO> GetAll()
        {
            return MapDTO.MapList<InvoiceDTO, Invoice>(_uow.InvoiceRepo.GetAll());
        }

        public InvoiceDTO Update(InvoiceDTO c)
        {
            try
            {
                _uow.InvoiceRepo.Modify(MapDTO.Map<Invoice, InvoiceDTO>(c));
                _uow.Save();
                return c;
            }
            catch (Exception e)
            {
                log.Error("kon niet updaten");
                throw new Exception(e.Message);
            }
        }

        public static int getCounter()
        {
            int temp = counter;
            counter = 0;
            return temp;
        }
    }
}
