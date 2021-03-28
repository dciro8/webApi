using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record UpdateItemDto
    {
        [Required]
        [Range(1, 1000)]
        public decimal Price { get; init; }

        [Required]
        public string Name { get; init; }

    }
}