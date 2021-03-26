using catalog.Entities;
using catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace catalog.Controllers
{

    //GET /imtes
    [ApiController]
    [Route("[items]")]
    public class ItemsController : ControllerBase
    {
        private readonly InMemItemsRepository repository;

        public ItemsController()
        {
            repository = new InMemItemsRepository();
        }
        //get /Items
        [HttpGet]
        public System.Collections.Generic.IEnumerable<Item> GetItems()
        {
            var items = repository.GetItems();
            return items;
        }
    }
}