using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Class;
using CarWorkshop.Repositories;
using System.Net;

namespace CarWorkshop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersRepository usersRepository;
        public UsersController(UsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            if(usersRepository.AllUsers() != null)
            {
                return Ok(usersRepository.AllUsers());
            }
            return StatusCode(404);
        }

        [HttpGet("id:int")]
        public ActionResult GetById(int user_id)
        {
            User userToFind = usersRepository.GetById(user_id);
            if (userToFind == null)
            {
                return StatusCode(404);
            }
            return Ok(userToFind);
             
        }

        [HttpPost]
        public ActionResult Post(User user) 
        {
            User userToFind = usersRepository.GetById(user.user_id);
            if (userToFind != null) 
            {
                return StatusCode(400,"Такого пользователя не существует");
            }
            usersRepository.Add(user);
            return Ok("Пользователь был создан");

        }

        [HttpPut]
        public ActionResult Put(User user)
        {
            if(usersRepository.GetById(user.user_id) == null)
            {
                return StatusCode(400,"Пользователя с таким id не существует");
            }
            usersRepository.Update(user);
            return Ok($"Пользователь с id {user.user_id} был обновлен");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (usersRepository.GetById(id) == null)
            {
                return StatusCode(400,"Пользователя с таким id не существует");
            }
            usersRepository.Delete(id);
            return Ok($"Пользователь с id {id} был удален");
        }
            

    }
}

