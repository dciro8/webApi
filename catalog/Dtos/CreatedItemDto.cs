using System;

namespace Catalog.Dtos
{
    public record CreatedItemDto
    {
        public decimal Price { get; init; }
        public string Name { get; init; }

    }
}