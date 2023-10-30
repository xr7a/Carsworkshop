
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
            return connection.Query<Order>("SELECT * FROM orders WHERE order_id = @order_id", new { orderId }).FirstOrDefault();
        }

        public List<Order> GetOrdersByCar(int car_id)
        {
            return connection.Query<Order>("SELECT * FROM order WHERE car_id = @car_id", new { car_id }).ToList();
        }

        public List<Order> GetOrdersByUser(int user_id)
        {
            return connection.Query<Order>("SELECT * FROM order WHERE user_id = @user_id", new {  user_id }).ToList();
        }

        public void Add(Order order)
        {
            var sql = @"INSERT INTO orders (order_id, user_id, car_id, ordertime, orderdescription, orderstatus, user_id, car_id) VALUES (@order_id, @user_id, @car_id, @ordertime, @orderdescription, @orderstatus, @user_id, @car_id)";
            connection.Execute(sql, order);
        }
        public void Update(Order order)
        {
            var sql = @"UPDATE orders SET ordertime = @ordertime, orderdescription = @orderdescription, orderstatus = @orderstatus";
            connection.Execute(sql, order);
        }
        public void Delete(int order_id)
        {
            var sql = "DELETE FROM orders WHERE order_id = @order_id";
            connection.Execute(sql, new { order_id });

        }
    }
}