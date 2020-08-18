using System;
using System.Collections.Generic;

namespace Webshop.DAL.Entit
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
        public string InvoiceCode { get; set; }
        public bool Deleted { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public string Email { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }

        public Invoice(DateTime date, bool isPaid, bool deleted, string invoiceCode,
            ICollection<InvoiceDetail> invoiceDetails, string email, string surname, string firstname)
        {
            this.Date = date;
            this.IsPaid = isPaid;
            this.Deleted = deleted;
            this.InvoiceCode = invoiceCode;
            this.InvoiceDetails = invoiceDetails;
            this.Email = email;
            this.Surname = surname;
            this.Firstname = firstname;
        }

        public Invoice()
        {
        }
    }
}