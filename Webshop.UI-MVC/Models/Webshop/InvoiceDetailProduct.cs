using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.UI_MVC.Models.Webshop
{
    public class InvoiceDetailProduct
    {
        public int InvoiceDetailId { get; set; }
        public InvoiceDetail InvoiceDetail { get; set; }
        public Product Products { get; set; }
        public int ProductId { get; set; }
    }
}