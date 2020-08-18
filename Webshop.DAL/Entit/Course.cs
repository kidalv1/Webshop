namespace Webshop.DAL.Entit
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public Course(string name, decimal price, Product product)
        {
            Name = name;
            Price = price;
            Product = product;
        }
        public Course()
        {

        }
    }
}
