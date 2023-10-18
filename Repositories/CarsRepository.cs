using System.Xml.Linq;
using CarWorkshop.Class;

namespace CarWorkshop.Repositories
{
    public class CarsRepository
    {
        public static List<Car> cars = new List<Car>()
        {
            new Car
            {
                CarId = 0,
                Name = "Mersedes Benz",
                Model = "AMG 500",
                YearOfRelease = 2006,
                VinCode = "Z624034908093",
                UserOfCar = UsersRepository.users[0]
            },
            new Car
            {
                CarId = 1,
                Name = "Audi ",
                Model = "A6",
                YearOfRelease = 2016,
                VinCode = "Z624034352081",
                UserOfCar = UsersRepository.users[1]
            }
        };
        public List<Car> GetCars()
        {
            return cars;
        }
        public void Add(Car car)
        {
            cars.Add(car);
        }
        public void Update(Car car)
        {
            Car CarToUpdate = cars.Find(c => c.CarId == car.CarId);
            if (CarToUpdate != null)
            {
                CarToUpdate.Name = car.Name;
                CarToUpdate.Model = car.Model;
                CarToUpdate.YearOfRelease = car.YearOfRelease;
                CarToUpdate.VinCode = car.VinCode;
            }
        }
        public void Delete(int id)
        {
            Car CarToDelete = cars.Find(c => c.CarId == id);
            if (CarToDelete != null)
            {
                cars.Remove(CarToDelete);
            }

        }
    }
}
