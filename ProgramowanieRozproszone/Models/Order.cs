namespace ProgramowanieRozproszone.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public Client Client { get; set; }
        public List<Product> Products { get; set; }
    }
}
