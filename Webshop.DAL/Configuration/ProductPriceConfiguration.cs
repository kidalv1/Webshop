using System.Data.Entity.ModelConfiguration;
using Webshop.DAL.Entit;

namespace Webshop.DAL.Configuration
{
    public class ProductPriceConfiguration : EntityTypeConfiguration<ProductPrice>
    {
        public ProductPriceConfiguration()
        {
            ToTable("ProductPrice");
            Property(pp => pp.Id).HasColumnType("int");
            Property(pp => pp.BeginDate).HasColumnType("Date");
            Property(pp => pp.EndTime).HasColumnType("Date");
            Property(pp => pp.ProductPrices).HasColumnType("decimal").HasPrecision(8, 2);

        }
    }
}
