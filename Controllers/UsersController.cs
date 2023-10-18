using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Class;
using CarWorkshop.Repositories;

namespace CarWorkshop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private UsersRepository usersRepository;
        //public UsersController(UsersRepository usersRepository)
        //{
        //    this.usersRepository = usersRepository;
        //}
        public UsersRepository usersRepository;
        public UsersController(UsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        [HttpGet]
        public ActionResult Get()
        {
            if (usersRepository.GetAll() == null)
            {
                return NotFound("Пользователи отсутсвуют");
            }
        return Ok(usersRepository.GetAll());
        }

        [HttpGet("id:int")]
        public ActionResult Get(int id)
        {
            User userToFind = usersRepository.GetAll().Find(c => c.Id == id);
            if (userToFind == null)
            {
                return NotFound("Пользователь не найден");
            }
            return Ok(userToFind);
             
        }

        [HttpPost]
        public ActionResult Post(User user) 
        {
            User userToFind = usersRepository.GetAll().Find(c => c.Id == user.Id);
            if (user.Id == userToFind.Id || user.PhoneNumber == userToFind.PhoneNumber) 
            {
                return BadRequest("Пользователь с такими данными уже существует");
            }
            if(user.Id < 0)
            {
                return BadRequest("Не может быть id меньше 0");
            }
            usersRepository.Add(user);
            return Ok("Пользователь был создан");

        }

        [HttpPut]
        public ActionResult Put(User user)
        {
            if(usersRepository.GetAll().Find(c => c.Id == user.Id) == null)
            {
                return NotFound("Пользователя с таким id не существует");
            }
            usersRepository.Update(user);
            return Ok($"Пользователь с id {user.Id} был обновлен");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (usersRepository.GetAll().Find(c => c.Id == id) == null)
            {
                return NotFound("Пользователя с таким id не существует");
            }
            usersRepository.Delete(id);
            return Ok($"Пользователь с id {id} был удален");
        }
            

    }
}

