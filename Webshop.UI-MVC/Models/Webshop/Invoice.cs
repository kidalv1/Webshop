using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.UI_MVC.Models.Webshop
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
        public string InvoiceCode { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public string Email { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }


        public Invoice()
        {
                
        }
        public Invoice(DateTime date, bool isPaid, bool deleted, string invoiceCode, string email, string surname, string firstname)
        {
            this.Date = date;
            this.IsPaid = isPaid;
            this.Deleted = deleted;
            this.InvoiceCode = invoiceCode;
            this.Email = email;
            this.Surname = surname;
            this.Firstname = firstname;
        }
    }
}