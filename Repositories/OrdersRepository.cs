
using CarWorkshop.Class;
using Dapper;
using System.Data;

namespace CarWorkshop.Repositories
{
    public class OrdersRepository
    {

        private IDbConnection connection;
        public OrdersRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public List<Order> GetAllOrders()
        {
            return connection.Query<Order>("SELECT * FROM orders").ToList();
        }

        public Order GetOrderById(int orderId)
        {
            return connection.Query<Order>("SELECT * FROM orders WHERE orderId = @orderId", new { orderId }).FirstOrDefault();
        }

        public List<Order> GetOrdersByCar(int carId)
        {
            return connection.Query<Order>("SELECT * FROM order WHERE carId = @carId", new { carId }).ToList();
        }

        public List<Order> GetOrdersByUser(int userId)
        {
            return connection.Query<Order>("SELECT * FROM order WHERE userId = @userId", new {  userId }).ToList();
        }

        public void Add(Order order)
        {
            var sql = @"INSERT INTO orders (orderId, orderTime, orderDescription, orderStatus, userId, carId) VALUES (@orderId, @orderTime, @orderDescription, @orderStatus, @userId, @carId)";
            connection.Execute(sql, order);
        }
        public void Update(Order order)
        {
            var sql = @"UPDATE orders SET orderTime = @orderTime, orderDescription = @orderDescription, orderStatus = @orderStatus";
            connection.Execute(sql, order);
        }
        public void Delete(int orderId)
        {
            var sql = "DELETE FROM orders WHERE orderId = @orderId";
            connection.Execute(sql, new { orderId });

        }
    }
}