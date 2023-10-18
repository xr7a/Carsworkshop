namespace CarWorkshop.Class
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderTime { get; set; }
        public string OrderDescription { get; set; }
        public string OrderStatus { get; set; }
        
        public User User { get; set; }
        public Car OrderCar { get; set; }
    }

}
