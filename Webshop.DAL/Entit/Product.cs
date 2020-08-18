using System;
using System.Collections.Generic;

namespace Webshop.DAL.Entit
{
   public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Vat> Vats { get; set; }
        public int PriceId { get; set; }
        public decimal Price { get; set; }
        public ProductPrice ProductPrice { get; set; }

        public Product()
        {

        }

        public Product(string name, int duration, DateTime startDate, DateTime endDate, ICollection<Course> courses, ICollection<Vat> vats, ProductPrice productPrice)
        {
            Name = name;
            Duration = duration;
            StartDate = startDate;
            EndDate = endDate;
            Courses = courses;
            Vats = vats;
            ProductPrice = productPrice;
        }
    }
}
