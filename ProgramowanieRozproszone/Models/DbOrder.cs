namespace ProgramowanieRozproszone.Models
{
    public class DbOrder
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int ClientId { get; set; }
    }
}
