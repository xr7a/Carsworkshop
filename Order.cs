namespace CarWorkshop
{
    public class Order : User
    {
        public int OrderId { get; set; }
        public DateTime OrderTime { get; set; }
        public string OrderDescription { get; set; }
        public string OrderStatus { get; set; }
    }
}