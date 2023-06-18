using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LAB_Fashion_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User> { 
            new User("Teste", "Masculino", new DateTime(), "55999999999", "teste@teste.com"),
            new User("Another Teste", "Masculino", new DateTime(), "55999999955", "anotherteste@teste.com"),
        };

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            return Ok(users[id]);
        }

        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            users.Add(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public ActionResult<User> Put(int id ,[FromBody] User user)
        {
            users[id] = user;
            return Ok(user);
        }

        [HttpPut("{id}/status")]
        public ActionResult<User> PutStatus(int id, [FromQuery]StatusType status)
        {
            users[id].Status = status;
            return Ok(users[id]);
        }
    }
}
