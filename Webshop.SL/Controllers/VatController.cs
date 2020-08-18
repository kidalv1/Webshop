using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Webshop.BL;
using Webshop.Domain;

namespace Webshop.SL.Controller
{
    public class VatController : ApiController
    {
        private ILogic<VatDTO> _vatLogic;

        public VatController(VatLogic logic)
        {
            _vatLogic = logic;
        }

        public IHttpActionResult GetVats()
        {
            return Ok(_vatLogic.GetAll().AsEnumerable());
        }

        public IHttpActionResult GetVat(int id)
        {
            var vat = _vatLogic.FindByID(id);

            if (vat == null)
            {
                return NotFound();
            }

            return Ok(vat);
        }

        [HttpPost]
        public IHttpActionResult CreateVat(VatDTO vatDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _vatLogic.Create(vatDto);
            return Created(new Uri(Request.RequestUri + "/" + vatDto.Id), vatDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateVat(VatDTO vatDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var vatInDb = _vatLogic.FindByID(vatDto.Id);

            if (vatInDb == null)
            {
                return NotFound();
            }

            return Ok(_vatLogic.Update(vatDto));
        }

        [HttpDelete]
        public IHttpActionResult DeleteVat(int id)
        {
            var vatInDb = _vatLogic.FindByID(id);

            if (vatInDb == null)
            {
                return NotFound();
            }

            _vatLogic.Delete(vatInDb);

            return Ok();
        }
    }
}
