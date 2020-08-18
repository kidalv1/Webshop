using System;
using System.ComponentModel.DataAnnotations;

namespace Webshop.DAL.Entit
{
    public class ProductPrice
    {
        public int Id { get; set; }
        public decimal ProductPrices { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndTime { get; set; }

        public ProductPrice(decimal productPrices, DateTime beginDate, DateTime endTime)
        {
            ProductPrices = productPrices;
            BeginDate = beginDate;
            EndTime = endTime;
        }

        public ProductPrice()
        {
            
        }
    }
}
