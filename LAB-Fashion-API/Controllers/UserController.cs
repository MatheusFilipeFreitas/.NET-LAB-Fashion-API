
using LAB_Fashion_API.Dto.UserDto;
using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Errors.User;
using LAB_Fashion_API.Filter;
using LAB_Fashion_API.Models;
using LAB_Fashion_API.Services.UriService;
using LAB_Fashion_API.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LAB_Fashion_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public UserController(IUserService service, IMapper mapper, IUriService uriService)
        {
            _service = service;
            _mapper = mapper;
            _uriService = uriService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> Get([FromQuery] PaginationFilter filter, [FromQuery] StatusType status)
        {
            return Ok(await _service.GetAllUsers(filter, route: Request.Path.Value, status));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetById(int id)
        {
            var returnValue = await _service.GetById(id);

            if (returnValue.Success)
            {
                return Ok(returnValue);
            }
            else if (returnValue.Messages.Contains("não foi encontrado"))
            {
                return NotFound(returnValue);
            }

            return BadRequest(returnValue);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Post(AddUserDto user)
        {
            var returnValue = await _service.AddUser(user);

            if(returnValue.Success)
            {
                //return CreatedAtAction(nameof(_service.GetUserByEmail), new { email = user.Email }, returnValue);
                return CreatedAtAction(nameof(GetById), new { id = returnValue.Data.Id }, returnValue.Data);
            }
            else if(returnValue.Messages.Contains("já cadastrado"))
            {
                return Conflict(returnValue);
            }
            else
            {
                return BadRequest(returnValue);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Put(int id ,UpdateUserDto user)
        {
            var returnValue = await _service.UpdateUser(id, user);
            if (returnValue.Success)
            {
                return Ok(returnValue);
            }else if(returnValue.Messages.Contains("não foi encontrado"))
            {
                return NotFound(returnValue);
            }
            else
            {
                return BadRequest(returnValue);
            }    
        }

        [HttpPut("{id}/status")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> PutStatus(int id, [FromBody] StatusType status)
        {
            var returnValue = await _service.UpdateUserStatus(id, status);
            if (returnValue.Success)
            {
                return Ok(returnValue);
            }
            else if (returnValue.Messages.Contains("não foi encontrado"))
            {
                return NotFound(returnValue);
            }
            else
            {
                return BadRequest(returnValue);
            }
        }
    }
}
