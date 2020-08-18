using System.Data.Entity.ModelConfiguration;
using Webshop.DAL.Entit;

namespace Webshop.DAL.Configuration
{
    public class InvoiceConfiguration : EntityTypeConfiguration<Invoice>
    {
        public InvoiceConfiguration()
        {
            ToTable("Invoice");
            Property(i => i.Id).HasColumnType("int");
            Property(i => i.Date).HasColumnType("Date");
            Property(i => i.IsPaid).HasColumnType("Bit");
            Property(i => i.InvoiceCode).HasColumnType("Varchar");
            Property(i => i.Deleted).HasColumnType("Bit");
            Property(i => i.Email).HasColumnType("Varchar");
            Property(i => i.Surname).HasColumnType("Varchar");
            Property(i => i.Firstname).HasColumnType("Varchar");

        }
    }
}
