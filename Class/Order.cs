namespace CarWorkshop.Class
{
    public class Order
    {
        public int orderId { get; set; }
        public string orderTime { get; set; }
        public string orderDescription { get; set; }
        public string orderStatus { get; set; }
        
        public int userId { get; set; }
        public int carId { get; set; }
    }

}
