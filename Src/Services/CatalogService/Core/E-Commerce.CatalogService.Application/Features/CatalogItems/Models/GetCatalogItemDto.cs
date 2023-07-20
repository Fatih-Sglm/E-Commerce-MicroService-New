namespace E_Commerce.CatalogService.Application.Features.CatalogItems.Models
{
    public class GetCatalogItemDto
    {
        public uint Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double Price { get; set; }
        public required string CatalogBrandName { get; set; }
        public required string CatalogTypeName { get; set; }
        public IList<string>? CatalogItemsImagesPath { get; set; }
        public IList<string>? CatalogItemsVariants { get; set; }
    }
}
