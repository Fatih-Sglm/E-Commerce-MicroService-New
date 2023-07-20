using Microsoft.AspNetCore.Http;

namespace E_Commerce.CatalogService.Application.Features.CatalogItems.Models
{
    public class UpdateCatalogItemDto
    {
        public uint Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public uint CatalogBrandId { get; set; }
        public uint CatalogTypeId { get; set; }
        public IFormFileCollection? ImagesPath { get; set; }

    }
}
