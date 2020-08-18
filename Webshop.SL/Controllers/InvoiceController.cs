using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Webshop.BL;
using Webshop.Domain;

namespace Webshop.SL.Controllers
{
    public class InvoiceController : ApiController
    {
        private ILogic<InvoiceDTO> _invoiceLogic;
        
        public InvoiceController(InvoiceLogic logic)
        {
            _invoiceLogic = logic;
        }

        public IHttpActionResult GetInvoices()
        {
            return Ok(_invoiceLogic.GetAll().AsEnumerable());
        }

        public IHttpActionResult GetInvoice(int id)
        {
            var invoice = _invoiceLogic.FindByID(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }

        [HttpPost]
        public IHttpActionResult CreateInvoice(InvoiceDTO invoiceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _invoiceLogic.Create(invoiceDto);
            return Created(new Uri(Request.RequestUri + "/" + invoiceDto.Id), invoiceDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateInvoice(InvoiceDTO invoiceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var invoiceInDb = _invoiceLogic.FindByID(invoiceDto.Id);

            if (invoiceInDb == null)
            {
                return NotFound();
            }

            return Ok(_invoiceLogic.Update(invoiceDto));
        }

        [HttpDelete]
        public IHttpActionResult DeleteInvoice(int id)
        {
            var invoiceInDb = _invoiceLogic.FindByID(id);

            if (invoiceInDb == null)
            {
                return NotFound();
            }

            _invoiceLogic.Delete(invoiceInDb);

            return Ok();
        }

       
  }
}
