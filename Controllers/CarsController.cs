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
        public ActionResult Get()
        {
            if (carsRepository.GetCars() == null)
            {
                return NotFound("Автомобили отсутсвуют");
            }
            return Ok(carsRepository.GetCars());
        }

        [HttpGet("id:int")]
        public ActionResult Get(int id)
        {
            Car carToFind = carsRepository.GetCars().Find(c => c.CarId == id);
            if (carToFind == null)
            {
                return NotFound("Автомобиль не найден");
            }
            return Ok(carToFind);

        }

        [HttpPost]
        public ActionResult Post(Car car)
        {
            Car carToFind = carsRepository.GetCars().Find(c => c.CarId == car.CarId);
            if (carToFind == null)
            {
            
                if (car.CarId < 0)
                {
                    return BadRequest("Не может быть id меньше 0");
                }
                carsRepository.Add(car);
                return Ok("Автомобиль был добавлен в базу");

            }
            else
            {
                if (car.CarId == carToFind.CarId || car.VinCode == carToFind.VinCode)
                {
                    return BadRequest("Автомобиль с такими данными уже существует");
                }
            }
            return Ok();

        }

        [HttpPut]
        public ActionResult Put(Car car)
        {
            if (carsRepository.GetCars().Find(c => c.CarId == car.CarId) == null)
            {
                return NotFound("Автомобиль с таким id не существует");
            }
            carsRepository.Update(car);
            return Ok($"Автомобиль с id {car.CarId} был обновлен");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (carsRepository.GetCars().Find(c => c.CarId == id) == null)
            {
                return NotFound("Автомобиля с таким id не существует");
            }
            carsRepository.Delete(id);
            return Ok($"Автомобиль с id {id} был удален");
        }


    }
}

