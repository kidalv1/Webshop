using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Domain
{
    public class InvoiceDTO
    {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public bool IsPaid { get; set; }
            public string InvoiceCode { get; set; }
            public ICollection<InvoiceDetailDTO> InvoiceDetails { get; set; }
            public bool Deleted { get; set; }
            public string Email { get; set; }
            public string Surname { get; set; }
            public string Firstname { get; set; }

        public InvoiceDTO()
            {

            }
    }
}
