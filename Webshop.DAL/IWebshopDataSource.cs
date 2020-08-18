using System.Linq;
using Webshop.DAL.Entit;

namespace Webshop.DAL
{
    interface IWebshopDataSource
    {
        IQueryable<Invoice> Invoices { get; }
        IQueryable<InvoiceDetail> InvoiceDetails { get; }
        IQueryable<Vat> Vats { get; }
        IQueryable<Course> Courses { get; }
        IQueryable<Product> Products { get; }
        IQueryable<ProductPrice> ProductPrices { get; }
    }
}
