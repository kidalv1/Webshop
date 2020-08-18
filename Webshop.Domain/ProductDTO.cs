using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Domain
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<CourseDTO> Courses { get; set; }
        public ICollection<VatDTO> Vats { get; set; }
        public int PriceId { get; set; }
        public decimal Price { get; set; }
        public ICollection<ProductPriceDTO> ProductPrices { get; set; }
    }
}
