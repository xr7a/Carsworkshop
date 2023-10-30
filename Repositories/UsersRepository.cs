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

        public User GetById(int user_id)
        {
            return connection.Query<User>("SELECT * FROM users WHERE user_id = @user_id", new { user_id }).FirstOrDefault();
        }

        public void Add(User user)
        {
            string commandText = @"INSERT INTO users (user_id,first_name, last_name, email, phonenumber, adress) VALUES (@user_id, @first_name, @last_name, @email, @phonenumber, @adress)";
            connection.Execute(commandText, user);
        }
        public void Update(User user)
        {
            var sql = "UPDATE users SET first_name = @first_name, last_name = @last_name, email = @email, phonenumber = @phonenumber, adress = @adress"; 
            connection.Execute(sql, user);
        }
        public void Delete(int id)
        {
            var sql = "DELETE FROM users WHERE user_id = @user_id";
            connection.Execute(sql, new {id});
        }
    }
}
