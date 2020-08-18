namespace Webshop.DAL.Entit
{
    public class InvoiceDetailProduct
    {
        public int InvoiceDetailId { get; set; }
        public InvoiceDetail InvoiceDetail { get; set; }
        public Product Products { get; set; }
        public int ProductId { get; set; }

        public InvoiceDetailProduct(InvoiceDetail invoiceDetail, Product products, int productId)
        {
            InvoiceDetail = invoiceDetail;
            Products = products;
            ProductId = productId;
        }

        public InvoiceDetailProduct()
        {
            
        }
    }
}
