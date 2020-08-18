using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Webshop.Domain;
using Webshop.BL;

namespace Webshop.SL.Controllers
{
    public class InvoiceDetailController : ApiController
    {
        private ILogic<InvoiceDetailDTO> _invoiceDetailLogic;

        public InvoiceDetailController(InvoiceDetailLogic logic)
        {
            _invoiceDetailLogic = logic;
        }

        public IHttpActionResult GetInvoiceDetails()
        {
            return Ok(_invoiceDetailLogic.GetAll().AsEnumerable());
        }

        public IHttpActionResult GetInvoiceDetail(int id)
        {
            var invoiceDetail = _invoiceDetailLogic.FindByID(id);

            if (invoiceDetail == null)
            {
                return NotFound();
            }

            return Ok(invoiceDetail);
        }

        [HttpPost]
        public IHttpActionResult CreateInvoiceDetail(InvoiceDetailDTO invoiceDetailDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _invoiceDetailLogic.Create(invoiceDetailDto);
            return Created(new Uri(Request.RequestUri + "/" + invoiceDetailDto.Id), invoiceDetailDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateInvoiceDetail(InvoiceDetailDTO invoiceDetailDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var invoiceDetailInDb = _invoiceDetailLogic.FindByID(invoiceDetailDto.Id);

            if (invoiceDetailInDb == null)
            {
                return NotFound();
            }

            return Ok(_invoiceDetailLogic.Update(invoiceDetailDto));
        }

        [HttpDelete]
        public IHttpActionResult DeleteInvoiceDetail(int id)
        {
            var invoiceDetailInDb = _invoiceDetailLogic.FindByID(id);

            if (invoiceDetailInDb == null)
            {
                return NotFound();
            }

            _invoiceDetailLogic.Delete(invoiceDetailInDb);

            return Ok();
        }
    }
}
