using CarWorkshop.Class;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CarWorkshop.Repositories
{
    public class UsersRepository
    {
        private IDbConnection connection;
        

        public UsersRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public List<User> AllUsers()
        {
            return connection.Query<User>("SELECT * FROM users").ToList();
        }

        public User GetById(int id)
        {
            return connection.Query<User>("SELECT * FROM users WHERE id = @id", new { id }).FirstOrDefault();
        }

        public void Add(User user)
        {
            string commandText = @"INSERT INTO users (id,FirstName, LastName, Email, Phone, Adress) VALUES (@id, @FirstName, @LastName, @Email, @Phone, @Adress)";
            connection.Execute(commandText, user);
        }
        public void Update(User user)
        {
            var sql = "UPDATE users SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, Adress = @Adress"; 
            connection.Execute(sql, user);
        }
        public void Delete(int id)
        {
            var sql = "DELETE FROM users WHERE id = @id";
            connection.Execute(sql, new {id});
        }
    }
}
