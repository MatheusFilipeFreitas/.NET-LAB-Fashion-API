using LAB_Fashion_API.Dto.User;
using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Errors.User;
using LAB_Fashion_API.Filter;
using LAB_Fashion_API.Models;
using LAB_Fashion_API.Services.CollectionService;
using LAB_Fashion_API.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace LAB_Fashion_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionService _service;

        public CollectionController(ICollectionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Collection>>>> Get([FromQuery] StatusType status)
        {
            var returnValue = await _service.GetAllCollections(status);
            return Ok(returnValue);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Collection>>> GetById(int id)
        {
            var returnValue = await _service.GetById(id);
            if(returnValue.Success)
            {
                return Ok(returnValue);
            }else if(returnValue.Messages.Contains("não foi encontrado")) {
                return NotFound(returnValue);
            }
            else
            {
                return BadRequest(returnValue);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Collection>>> Post(Collection collection)
        {
            var returnValue = await _service.AddCollection(collection);
            if (returnValue.Success)
            {
                return CreatedAtAction(nameof(GetById), new { id = returnValue.Data.Id }, returnValue.Data);
            }
            else if (returnValue.Messages.Contains("já cadastrado"))
            {
                return Conflict(returnValue);
            }
            else
            {
                return BadRequest(returnValue);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<Collection>>> Put(int id, Collection collection)
        {
            var returnValue = await _service.UpdateCollection(id, collection);
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

        [HttpPut("{id}/status")]
        public async Task<ActionResult<ServiceResponse<Collection>>> PutStatus(int id, [FromQuery] StatusType status)
        {
            var returnValue = await _service.UpdateCollectionStatus(id, status);
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Collection>>> Delete(int id)
        {
            var returnValue = await _service.DeleteCollection(id);
            if (returnValue.Success)
            {
                return NoContent();
            }else if(returnValue.Messages.Contains("não foi encontrado"))
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
