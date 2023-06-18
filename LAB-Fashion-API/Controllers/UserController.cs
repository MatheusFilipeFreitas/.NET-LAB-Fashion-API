using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LAB_Fashion_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // private static User user = new User("Teste", "Masculino", new DateTime(), "00000000000", null, "55999999999", "teste@teste.com");

        [HttpGet]
        /*
        public ActionResult<User> Get()
        {
            return Ok();
        }*/
        public string Get()
        {
            return "Get method called";
        }

        [HttpGet("{id}")]
        public string GetById(int id)
        {
            return "Get by Id method called";
        }

        [HttpPost]
        public string Post()
        {
            return "Post method called";
        }

        [HttpPut]
        public string Put()
        {
            return "Put method called";
        }

        [HttpPut("/status")]
        public string PutStatus([FromQuery]StatusType status)
        {
            return status.ToString();
        }
    }
}
