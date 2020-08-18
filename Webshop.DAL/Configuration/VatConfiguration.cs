using System.Data.Entity.ModelConfiguration;
using Webshop.DAL.Entit;

namespace Webshop.DAL.Configuration
{
    public class VatConfiguration : EntityTypeConfiguration<Vat>
    {
        public VatConfiguration()
        {
            ToTable("Vat");
            Property(v => v.Id).HasColumnType("int");
            Property(v => v.Percentage).HasColumnType("int");
        }
    }
}
