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
    public class ProductPriceController : ApiController
    {
        private ILogic<ProductPriceDTO> _productPriceLogic;

        public ProductPriceController(ProductPriceLogic logic)
        {
            _productPriceLogic = logic;
        }

        //GET /api/productprice
        public IHttpActionResult GetProductPrices()
        {
            return Ok(_productPriceLogic.GetAll().AsEnumerable());
        }

        //GET /api/productprice/1
        public IHttpActionResult GetProductPrice(int id)
        {
            var productPrice = _productPriceLogic.FindByID(id);

            if (productPrice == null)
            {
                return NotFound();
            }

            return Ok(productPrice);
        }

        //POST /api/productprice
        [HttpPost]
        public IHttpActionResult AddProductPrice(ProductPriceDTO productPriceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _productPriceLogic.Create(productPriceDto);
            return Created(new Uri(Request.RequestUri + "/" + productPriceDto.Id), productPriceDto);
        }

        //PUT /api/productprice/1
        [HttpPut]
        public IHttpActionResult UpdateProductPrice(ProductPriceDTO productPriceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var productPriceInDb = _productPriceLogic.FindByID(productPriceDto.Id);

            if (productPriceInDb == null)
            {
                return NotFound();
            }

            return Ok(_productPriceLogic.Update(productPriceDto));
        }

        //Delete /api/productprice/1
        [HttpDelete]
        public IHttpActionResult DeleteProductPrice(int id)
        {
            var productPriceInDb = _productPriceLogic.FindByID(id);

            if (productPriceInDb == null)
            {
                return NotFound();
            }

            _productPriceLogic.Delete(productPriceInDb);

            return Ok();
        }
    }
}
