
using System;
using System.Collections.Generic;
using System.Linq;
using catalog.Entities;

namespace catalog.Repositories
{
    public class InMemItemsRepository
    {
        private readonly List<Item> items = new() {
            new Item {
                Id= System.Guid.NewGuid(),
                Name= "Potion",
                Price=9,
                CreatedDate = DateTimeOffset.UtcNow },
                new Item {
                Id= System.Guid.NewGuid(),
                Name= "Iron sword",
                Price=20,
                CreatedDate = DateTimeOffset.UtcNow },
                new Item {
                Id= System.Guid.NewGuid(),
                Name= "Bronze Shield",
                Price=19,
                CreatedDate = DateTimeOffset.UtcNow }
        };

        public IEnumerable<Item> GetItems(){
            return items;
        }
           public Item GetItem(Guid id){
            return items.Where(items => items.Id == id).SingleOrDefault();
        }

    }
}