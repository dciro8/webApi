using System.Collections.Generic;
using Catalog.Entities;
using catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using Catalog.Repositories;
using System.Linq;
using Catalog.Dtos;
using Catalog;

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
            this.repository = repository;
        }
        //get /Items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems()
            .Select(item => item.AsDto());
            return items;
        }
        //Get / items/ID
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost]
        public ActionResult<ItemDto> createItem(CreatedItemDto itemDto)
        {

            Item item = new Item()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }


        [HttpPut("{id}")]
        public ActionResult<ItemDto> UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = repository.GetItem(id);
            if (existingItem is null)
            { 
                return NotFound();
            }
            Item updatedItem = existingItem with {
                Name= itemDto.Name,
                Price=itemDto.Price
            };
            repository.UpdateItem(updatedItem);
            return NoContent();
        }
    }
}