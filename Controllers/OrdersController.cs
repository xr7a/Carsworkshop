using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Class;
using CarWorkshop.Repositories;

namespace CarWorkshop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private OrdersRepository ordersRepository;
        public OrdersController(OrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }
        [HttpGet]
        public ActionResult Get()
        {
            if (ordersRepository.GetAllOrders() == null)
            {
                return NotFound("Заказы отсутсвуют");
            }
            return Ok(ordersRepository.GetAllOrders());
        }

        [HttpGet("id:int")]
        public ActionResult Get(int id)
        {
            Order orderToFind = ordersRepository.GetAllOrders().Find(c => c.OrderId == id);
            if (orderToFind == null)
            {
                return NotFound("Заказ не найден");
            }
            return Ok(orderToFind);

        }

        [HttpGet("UserId:int")]
        public ActionResult GetUserCars(int id)
        {

            var UserOrders = new List<Order>();
            if (ordersRepository.GetAllOrders().Find(c => c.User.Id == id) == null)
            {
                return NotFound("Такого пользователя не существует");
            }
            foreach (Order order in ordersRepository.GetAllOrders())
            {
                if (order.User.Id == id)
                {
                    UserOrders.Add(order);
                }
            }
            return Ok(UserOrders);
        }

        [HttpPost]
        public ActionResult Post(Order order)
        {
            Order orderToFind = ordersRepository.GetAllOrders().Find(c => c.OrderId == order.OrderId);
            if (orderToFind == null)
            {
                if (order.OrderId < 0)
                {
                    return BadRequest("Не может быть id меньше 0");
                }
                ordersRepository.Add(order);
                return Ok("Заказ был добавлен в базу");

            }
            else
            {
                if (order.OrderId == orderToFind.OrderId)
                {
                    return BadRequest("Заказ с такими данными уже существует");
                }
            }
            return Ok();

        }

        [HttpPut]
        public ActionResult Put(Order order)
        {
            if (ordersRepository.GetAllOrders().Find(c => c.OrderId == order.OrderId) == null)
            {
                return NotFound("Заказа с таким id не существует");
            }
            ordersRepository.Update(order);
            return Ok($"Заказ с id {order.OrderId} был обновлен");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (ordersRepository.GetAllOrders().Find(c => c.OrderId == id) == null)
            {
                return NotFound("Заказа с таким id не существует");
            }
            ordersRepository.Delete(id);
            return Ok($"Заказ с id {id} был удален");
        }


    }
}

