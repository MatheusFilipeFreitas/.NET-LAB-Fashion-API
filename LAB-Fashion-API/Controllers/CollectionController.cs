using LAB_Fashion_API.Dto.CollectionDto;
using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Filter;
using LAB_Fashion_API.Services.CollectionService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LAB_Fashion_API.Controllers
{
    [Authorize]
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
        public async Task<ActionResult<ServiceResponse<List<GetCollectionDto>>>> Get([FromQuery] PaginationFilter filter, [FromQuery] StatusType status)
        {
            return Ok(await _service.GetAllCollections(filter, route: Request.Path.Value, status));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCollectionDto>>> GetById(int id)
        {
            var returnValue = await _service.GetById(id);
            if(returnValue.Success)
            {
                return Ok(returnValue);
            }
            else if(returnValue.Messages.Contains("não foi encontrado")) {
                return NotFound(returnValue);
            }
            else
            {
                return BadRequest(returnValue);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCollectionDto>>> Post(AddCollectionDto collection)
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
        public async Task<ActionResult<ServiceResponse<GetCollectionDto>>> Put(int id, UpdateCollectionDto collection)
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
        public async Task<ActionResult<ServiceResponse<GetCollectionDto>>> PutStatus(int id,[FromBody] StatusType status)
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
        public async Task<ActionResult<ServiceResponse<GetCollectionDto>>> Delete(int id)
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
