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
                return StatusCode(404,"Заказы отсутсвуют");
            }
            return Ok(ordersRepository.GetAllOrders());
        }

        [HttpGet("id:int")]
        public ActionResult Get(int id)
        {
            Order orderToFind = ordersRepository.GetOrderById(id);
            if (orderToFind == null)
            {
                return StatusCode(404,"Заказ не найден");
            }
            return Ok(orderToFind);

        }

        [HttpGet("UserId:int")]
        public ActionResult GetUserOrders(int id)
        {
            if (ordersRepository.GetOrdersByUser(id) != null)
            {
                return Ok(ordersRepository.GetOrdersByUser(id));
            }
            return StatusCode(404);
        }

        [HttpGet("CarId:int")]
        public ActionResult GetCarOrders(int id)
        {
            if (ordersRepository.GetOrdersByCar(id) != null)
            {
                return Ok(ordersRepository.GetOrdersByCar(id));
            }
            return StatusCode(404);
        }

        [HttpPost]
        public ActionResult Post(Order order)
        {
            Order orderToFind = ordersRepository.GetOrderById(order.orderId);
            if (orderToFind != null)
            {
                return StatusCode(400, "Такой заказ уже существует!");
            }
            ordersRepository.Add(order);
            return Ok("Заказ был добавлен в базу");

        }

        [HttpPut]
        public ActionResult Put(Order order)
        {
            if (ordersRepository.GetOrderById(order.orderId) == null)
            {
                return StatusCode(404,"Заказа с таким id не существует");
            }
            ordersRepository.Update(order);
            return Ok($"Заказ с id {order.orderId} был обновлен");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (ordersRepository.GetOrderById(id) == null)
            {
                return StatusCode(404,"Заказа с таким id не существует");
            }
            ordersRepository.Delete(id);
            return Ok($"Заказ с id {id} был удален");
        }


    }
}

