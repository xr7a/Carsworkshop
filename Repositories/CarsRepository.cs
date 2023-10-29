using System.Data;
using System.Xml.Linq;
using CarWorkshop.Class;
using Dapper;

namespace CarWorkshop.Repositories
{
    public class CarsRepository
    {
        private IDbConnection connection;

        public CarsRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public List<Car> AllCars()
        {
            return connection.Query<Car>("SELECT * FROM cars").ToList();
        }

        public Car GetCarById(int carId)
        {
            return connection.Query<Car>("SELECT * FROM cars WHERE carId = @carId", new { carId }).FirstOrDefault();
        }

        public List<Car> GetCarsByUser(int userId)
        {
            return connection.Query<Car>("SELECT * FROM cars WHERE userId = @userId", new[] { userId }).ToList();
        }

        public void Add(Car car)
        {
            string sql = @"INSERT INTO cars (carId, Name, Model, YearOfRelease, VinCode ) VALUES (@carId, @Name, @Model, @YearOfRelease, @VinCode)";
            connection.Execute(sql, car);
        }

        public void Update(Car car)
        {
            var sql = @"UPDATE cars SET Name = @Name, Model = @Model, YearOfRelease = @YearOfRelease";
            connection.Execute(sql, car);
        }

        public void Delete(int carId)
        {
            var sql = @"DELETE FROM cars WHERE carId = @carId";
            connection.Execute(sql, new { carId });
        }
    }
}
