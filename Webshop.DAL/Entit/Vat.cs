namespace Webshop.DAL.Entit
{
    public class Vat
    {
        public int Id { get; set; }
        public int Percentage { get; set; }

        public Vat(int percentage)
        {
            Percentage = percentage;
        }

        public Vat()
        {
            
        }
    }
}
