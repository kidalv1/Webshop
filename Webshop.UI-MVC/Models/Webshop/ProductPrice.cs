using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.UI_MVC.Models.Webshop
{
    public class ProductPrice
    {
        public int Id { get; set; }
        public decimal ProductPrices { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndTime { get; set; }

        public ProductPrice()
        {
            
        }

        public ProductPrice(decimal price, DateTime begin, DateTime end)
        {
            ProductPrices = price;
            BeginDate = begin;
            EndTime = end;
        }
    }
}