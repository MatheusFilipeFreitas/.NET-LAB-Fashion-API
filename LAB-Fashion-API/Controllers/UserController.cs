using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Models;
using LAB_Fashion_API.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace LAB_Fashion_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return Ok(_service.GetAllUsers());
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            return Ok(_service.AddUser(user));
        }

        [HttpPut("{id}")]
        public ActionResult<User> Put(int id ,User user)
        {
            return Ok(_service.UpdateUser(id, user));
        }

        [HttpPut("{id}/status")]
        public ActionResult<User> PutStatus(int id, [FromQuery]StatusType status)
        {
            return Ok(_service.UpdateUserStatus(id, status));
        }
    }
}
