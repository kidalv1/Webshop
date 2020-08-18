using System.Data.Entity.ModelConfiguration;
using Webshop.DAL.Entit;

namespace Webshop.DAL.Configuration
{
    public class InvoiceDetailConfiguration : EntityTypeConfiguration<InvoiceDetail>
    {
        public InvoiceDetailConfiguration()
        {
            ToTable("InvoiceDetail");
            Property(id => id.Id).HasColumnType("int");
            Property(id => id.Pieces).HasColumnType("int");
        }
    }
}
