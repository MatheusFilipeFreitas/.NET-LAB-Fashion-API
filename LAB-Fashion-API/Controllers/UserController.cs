using LAB_Fashion_API.Dto.User;
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
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> Get()
        {
            return Ok(await _service.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Post(AddUserDto user)
        {
            return Ok(await _service.AddUser(user));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Put(int id ,AddUserDto user)
        {
            return Ok(await _service.UpdateUser(id, user));
        }

        [HttpPut("{id}/status")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> PutStatus(int id, [FromQuery]StatusType status)
        {
            return Ok(await _service.UpdateUserStatus(id, status));
        }
    }
}
