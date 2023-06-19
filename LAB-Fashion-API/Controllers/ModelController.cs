using LAB_Fashion_API.Models;
using Microsoft.AspNetCore.Mvc;
using LAB_Fashion_API.Enums;

namespace LAB_Fashion_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModelController : ControllerBase
    {
        List<Model> models = new List<Model> {
                new Model(1, "Modelo Teste", null, 2, ModelType.Calça, LayoutType.Estampa),
                new Model(2, "Teste", null, 1, ModelType.Boné, LayoutType.Liso),
            };

        [HttpGet]
        public ActionResult<List<Model>> Get()
        {
            return Ok(models);
        }

        [HttpGet("{id}")]
        public ActionResult<Model> GetById(int id)
        {
            var model = models.FirstOrDefault(m => m.Id == id);
            return Ok(model);
        }

        [HttpPost]
        public ActionResult<Model> Post([FromBody] Model addModel)
        {
            models.Add(addModel);
            return CreatedAtAction(nameof(GetById), new { addModel.Id }, addModel);
        }

        [HttpPut("{id}")]
        public ActionResult<Model> Put(int id, [FromBody] Model updateModel)
        {
            var model = models.FirstOrDefault(m => m.Id == id);
            model.Name = updateModel.Name;
            model.CollectionId = updateModel.CollectionId;
            model.Layout = updateModel.Layout;
            model.Type = updateModel.Type;
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public ActionResult<Model> Delete(int id)
        {
            var model = models.FirstOrDefault(m => m.Id == id);
            models.Remove(model);
            return NoContent();
        }
    }
}
