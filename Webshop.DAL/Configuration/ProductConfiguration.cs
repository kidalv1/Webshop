using System.Data.Entity.ModelConfiguration;
using Webshop.DAL.Entit;

namespace Webshop.DAL.Configuration
{
    class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("Product");
            Property(p => p.Id).HasColumnType("int");
            Property(p => p.Duration).HasColumnType("int");
            Property(p => p.EndDate).HasColumnType("Date");
            Property(p => p.StartDate).HasColumnType("Date");
            Property(p => p.Name).HasColumnType("varchar").HasMaxLength(150);

            HasMany(p => p.Courses)
                .WithRequired(c => c.Product);
        }
    }
}
