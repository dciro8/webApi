using System;

namespace catalog.Entities
{
    public record Item
    {
        public Item()
        {
        }

        public Guid Id { get; init;}
        public string Name {get; init;}
         public decimal Price {get; init;}
         public DateTimeOffset CreatedDate {get; init;}
    }
}