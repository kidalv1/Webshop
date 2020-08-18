using System.Data.Entity.ModelConfiguration;
using Webshop.DAL.Entit;

namespace Webshop.DAL.Configuration
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            ToTable("Course");
            Property(c => c.Id);
            Property(c => c.Name).HasMaxLength(100);
            Property(c => c.Price).HasPrecision(8, 2);

        }
    }
}
