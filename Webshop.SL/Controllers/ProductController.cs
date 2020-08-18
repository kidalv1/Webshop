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
    public class ProductController : ApiController
    {
        private ILogic<ProductDTO> _productLogic;

        public ProductController(ProductLogic logic)
        {
            _productLogic = logic;
        }

        public IHttpActionResult GetProducts()
        {
            return Ok(_productLogic.GetAll().AsEnumerable());
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = _productLogic.FindByID(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IHttpActionResult CreateProduct(ProductDTO productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _productLogic.Create(productDto);
            return Created(new Uri(Request.RequestUri + "/" + productDto.Id), productDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateProduct(ProductDTO productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var productInDb = _productLogic.FindByID(productDto.Id);

            if (productInDb == null)
            {
                return NotFound();
            }

            return Ok(_productLogic.Update(productDto));
        }

        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            var productInDb = _productLogic.FindByID(id);

            if (productInDb == null)
            {
                return NotFound();
            }

            _productLogic.Delete(productInDb);

            return Ok();
        }
  }
}
