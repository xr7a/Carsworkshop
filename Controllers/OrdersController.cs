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

        [HttpPost]
        public ActionResult Post(Order order)
        {
            Order orderToFind = ordersRepository.GetAllOrders().Find(c => c.OrderId == order.OrderId);
            if (order.OrderId == orderToFind.OrderId)
            {
                return BadRequest("Автомобиль с такими данными уже существует");
            }
            if (order.OrderId < 0)
            {
                return BadRequest("Не может быть id меньше 0");
            }
            ordersRepository.Add(order);
            return Ok("Заказ был добавлен в базу");

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

