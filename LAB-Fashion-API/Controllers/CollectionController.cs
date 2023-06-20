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

        public static List<Collection> collections = new List<Collection> { 
                new Collection("Teste", 1, "Adidas", 32.45d, new DateTime(), Seasons.Winter),
                new Collection("Outro", 2, "Nike", 32.45d, new DateTime(), Seasons.Winter)
            };

        [HttpGet]
        public ActionResult<List<Collection>> Get()
        {
            return collections;
        }

        [HttpGet("{id}")]
        public ActionResult<Collection> GetById(int id)
        {
            return collections[id] ;
        }

        [HttpPost]
        public ActionResult<Collection> Post(Collection collection)
        {
            collections.Add(collection);
            return collection;
        }

        [HttpPut("{id}")]
        public ActionResult<Collection> Put(int id, Collection collection)
        {
            collections[id] = collection;
            return collection;
        }

        [HttpPut("{id}/status")]
        public ActionResult<Collection> PutStatus(int id, [FromQuery] StatusType status)
        {
            collections[id].Status = status;
            return collections[id];
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var collection = collections[id];
            collections.Remove(collection);
        }
    }
}
