
using CarWorkshop.Class;
namespace CarWorkshop.Repositories
{
    public class OrdersRepository
    {
        public static List<Order> orders = new List<Order>()
        {
            new Order
            {
                OrderId = 0,
                OrderTime = "09.10.2023" ,
                OrderDescription = "Починить двигатель",
                OrderStatus = "Выполняется",
                OrderCar = CarsRepository.cars[0],
                User = UsersRepository.users[0]
            },
            new Order
            {
                OrderId = 0,
                OrderTime = "09.10.2023" ,
                OrderDescription = "Починить двигатель",
                OrderStatus = "Выполняется",
                OrderCar = CarsRepository.cars[1],
                User = UsersRepository.users[1]
            }
        };
        public List<Order> GetAllOrders()
        {
            return orders;
        }
        public void Add(Order order)
        {
            orders.Add(order);
        }
        public void Update(Order order)
        {
            Order OrderToUpdate = orders.Find(c => c.OrderId == order.OrderId);
            if (OrderToUpdate != null)
            {
                OrderToUpdate.OrderTime = order.OrderTime;
                OrderToUpdate.OrderDescription = order.OrderDescription;
                OrderToUpdate.OrderStatus = order.OrderStatus;
            }
        }
        public void Delete(int id)
        {
            Order OrderToDelete = orders.Find(c => c.OrderId == id);
            if (OrderToDelete != null)
            {
                orders.Remove(OrderToDelete);
            }

        }
    }
}