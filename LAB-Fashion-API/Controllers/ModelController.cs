using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Filter;
using LAB_Fashion_API.Dto.ModelDto;
using LAB_Fashion_API.Services.ModelService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LAB_Fashion_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ModelController : ControllerBase
    {
        private readonly IModelService _service;

        public ModelController(IModelService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetModelDto>>>> Get([FromQuery] PaginationFilter filter, [FromQuery] LayoutType layout)
        {
            return Ok(await _service.GetAllModels(filter, Request.Path.Value, layout));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetModelDto>>> GetById(int id)
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
            else
            {
                return BadRequest(returnValue);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetModelDto>>> Post([FromBody] AddModelDto addModel)
        {
            var returnValue = await _service.AddModel(addModel);
            if (returnValue.Success)
            {
                return CreatedAtAction(nameof(GetById), new { id = returnValue.Data.Id }, addModel);
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
        public async Task<ActionResult<ServiceResponse<GetModelDto>>> Put(int id, [FromBody] UpdateModelDto updateModel)
        {
            var returnValue = await _service.UpdateModel(id, updateModel);
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
        public async Task<ActionResult<ServiceResponse<GetModelDto>>> Delete(int id)
        {
            var returnValue = await _service.DeleteModel(id);
            if (returnValue.Success)
            {
                return NoContent();
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
