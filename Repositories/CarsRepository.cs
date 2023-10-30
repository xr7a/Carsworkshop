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

        public Car GetCarById(int car_Id)
        {
            return connection.Query<Car>("SELECT * FROM cars WHERE car_id = @car_id", new { car_Id }).FirstOrDefault();
        }

        public List<Car> GetCarsByUser(int user_Id)
        {
            return connection.Query<Car>("SELECT * FROM cars WHERE user_id = @user_id", new{ user_Id }).ToList();
        }

        public void Add(Car car)
        {
            string sql = @"INSERT INTO cars (car_id, user_id, name, model, yearofrelease, vincode ) VALUES (@car_id, @user_id, @name, @model, @yearofrelease, @vincode)";
            connection.Execute(sql, car);
        }

        public void Update(Car car)
        {
            var sql = @"UPDATE cars SET name = @name, model = @model, yearofrelease = @yearofrelease";
            connection.Execute(sql, car);
        }

        public void Delete(int carId)
        {
            var sql = @"DELETE FROM cars WHERE car_id = @car_id";
            connection.Execute(sql, new { carId });
        }
    }
}
