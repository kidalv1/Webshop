namespace Webshop.DAL.Entit
{
    public class DetailCourse
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public InvoiceDetail InvoiceDetail { get; set; }
        public int InvoiceDetailId { get; set; }

        public DetailCourse(Course course, InvoiceDetail invoiceDetail, int invoiceDetailId)
        {
            Course = course;
            InvoiceDetail = invoiceDetail;
            InvoiceDetailId = invoiceDetailId;
        }
    }
}
