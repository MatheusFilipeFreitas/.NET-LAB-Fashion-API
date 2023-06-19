using Microsoft.AspNetCore.Mvc;

namespace LAB_Fashion_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModelController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "Get method called!";
        }

        [HttpGet("{id}")]
        public string GetById(int id)
        {
            return "Get by id method called!";
        }

        [HttpPost]
        public string Post([FromBody] string text)
        {
            return "Post method called!";
        }

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string text)
        {
            return "Put method called!";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "Delete method called!";
        }
    }
}
