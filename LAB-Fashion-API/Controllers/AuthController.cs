using LAB_Fashion_API.Dto.LoginDto;
using Microsoft.AspNetCore.Mvc;

namespace LAB_Fashion_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(Login credentials)
        {
            var response = await _authRepository.Login(credentials.Email, credentials.Password);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
