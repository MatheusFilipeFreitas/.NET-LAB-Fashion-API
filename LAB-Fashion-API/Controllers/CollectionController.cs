using LAB_Fashion_API.Dto.User;
using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Errors.User;
using LAB_Fashion_API.Filter;
using LAB_Fashion_API.Models;
using LAB_Fashion_API.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace LAB_Fashion_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Get method called";
        }

        [HttpGet("{id}")]
        public string GetById(int id)
        {
            return "Get by id method called";
        }

        [HttpPost]
        public string Post()
        {
            return "Post method called";
        }

        [HttpPut("{id}")]
        public string Put()
        {
            return "Put method called";
        }

        [HttpPut("{id}/status")]
        public string PutStatus(int id, [FromQuery] StatusType status)
        {
            return "Put status method called";
        }

        [HttpDelete]
        public string Delete()
        {
            return "Delete method called";
        }
    }
}
