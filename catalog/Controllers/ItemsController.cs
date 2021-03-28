using System.Collections.Generic;
using Catalog.Entities;
using catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using Catalog.Repositories;
using System.Linq;
using Catalog.Dtos;

namespace catalog.Controllers
{

    //GET /imtes
    [ApiController]
    [Route("api/'[['items']]'")]

    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
           this.repository =  repository;
        }
        //get /Items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems()
            .Select(item => new ItemDto{
                Id=item.Id,
                Name=item.Name,
                Price=item.Price,
                CreatedDate=item.CreatedDate
            });
            return items;
        }
        //Get / items/ID
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item is null){
                return NotFound();
            }

            return item;
        }
    }
}