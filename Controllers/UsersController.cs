using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Class;
using CarWorkshop.Repositories

namespace CarWorkshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
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
            usersRepository.GetAll();
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

    }
}
