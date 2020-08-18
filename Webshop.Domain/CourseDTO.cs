using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Domain
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal price { get; set; }
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }

        public CourseDTO()
        {
        }
    }
}