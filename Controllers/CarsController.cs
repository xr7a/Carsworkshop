using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Class;
using CarWorkshop.Repositories;

namespace CarWorkshop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        private CarsRepository carsRepository;
        public CarsController(CarsRepository carsRepository)
        {
            this.carsRepository = carsRepository;
        }
        [HttpGet]
        public ActionResult GetAllCars()
        {
            if (carsRepository.AllCars() != null)
            {
                return Ok(carsRepository.AllCars());
            }
            return StatusCode(404);
        }


        [HttpGet("id:int")]
        public ActionResult Get(int id)
        {
            Car carToFind = carsRepository.GetCarById(id);
            if (carToFind == null)
            {
                return StatusCode(404,"Автомобиль не найден");
            }
            return Ok(carToFind);

        }


        [HttpGet("UserId:int")]
        public ActionResult GetUserCars(int id)
        {
            if(carsRepository.GetCarsByUser != null)
            {
                return Ok(carsRepository.GetCarsByUser(id));
            }
            return StatusCode(400);
        }
    
    

        [HttpPost]
        public ActionResult Post(Car car)
        {
            Car carToFind = carsRepository.GetCarById(car.carId);
            if (carToFind != null)
            {
                return StatusCode(400, "Автомобиль с такими данными уже существует");
            }
            carsRepository.Add(car);
            return Ok("Автомобиль был добавлен в базу");
        }

        [HttpPut]
        public ActionResult Put(Car car)
        {
            if (carsRepository.GetCarById(car.carId) == null)
            {
                return StatusCode(404,"Автомобиль с таким id не существует");
            }
            carsRepository.Update(car);
            return Ok($"Автомобиль с id {car.carId} был обновлен");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (carsRepository.GetCarById == null)
            {
                return StatusCode(404,"Автомобиля с таким id не существует");
            }
            carsRepository.Delete(id);
            return Ok($"Автомобиль с id {id} был удален");
        }


    }
}

