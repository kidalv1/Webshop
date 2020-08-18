using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Domain
{
    public class InvoiceDetailDTO
    {
        public int Id { get; set; }
        public int Pieces { get; set; }
        public int CourseId { get; set; }
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
    }
}
