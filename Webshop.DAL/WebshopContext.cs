using System.Data.Entity;
using System.Linq;
using Webshop.DAL.Configuration;
using Webshop.DAL.Entit;

namespace Webshop.DAL
{
    public class WebshopContext : DbContext,IWebshopDataSource
    {
        public WebshopContext() : base("Webshop")
        {
        }

        public DbSet<Invoice> _Invoices { get; set; }
        public DbSet<InvoiceDetail> _InvoiceDetails { get; set; }
        public DbSet<Vat> _Vats { get; set; }
        public DbSet<Course> _Courses { get; set; }
        public DbSet<Product> _Products { get; set; }
        public DbSet<ProductPrice> _ProductPrices { get; set; }
    
        IQueryable<Invoice> IWebshopDataSource.Invoices => _Invoices;
        IQueryable<InvoiceDetail> IWebshopDataSource.InvoiceDetails => _InvoiceDetails;
        IQueryable<Vat> IWebshopDataSource.Vats => _Vats;
        IQueryable<Course> IWebshopDataSource.Courses => _Courses;
        IQueryable<Product> IWebshopDataSource.Products => _Products;
        IQueryable<ProductPrice> IWebshopDataSource.ProductPrices => _ProductPrices;

        public void CreateModelUser(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VatConfiguration());
            modelBuilder.Configurations.Add(new InvoiceConfiguration());
            modelBuilder.Configurations.Add(new InvoiceDetailConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new ProductPriceConfiguration());
        }
    }
}
