using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webshop.UI_MVC.Models.Webshop
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Vat> Vats { get; set; }
        public int PriceId { get; set; }
        public decimal Price { get; set; }
        public ICollection<ProductPrice> ProductPrices { get; set; }
    }
}