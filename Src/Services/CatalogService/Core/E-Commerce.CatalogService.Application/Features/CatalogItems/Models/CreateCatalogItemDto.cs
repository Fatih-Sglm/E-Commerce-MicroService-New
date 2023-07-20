using Microsoft.AspNetCore.Http;

namespace E_Commerce.CatalogService.Application.Features.CatalogItems.Models
{
    public class CreateCatalogItemDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public uint CatalogBrandId { get; set; }
        public uint CatalogTypeId { get; set; }
        public required string FolderPath { get; set; }
        public IFormFileCollection? Images { get; set; }
        public List<uint>? Variants { get; set; }
    }
}
