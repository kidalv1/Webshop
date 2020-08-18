using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.UI_MVC.Models.Webshop
{
    public class ShoppingCart
    {
        public Course Course { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}