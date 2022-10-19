namespace ProgramowanieRozproszone.Models
{
    public class DbOrder
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
    }
}
