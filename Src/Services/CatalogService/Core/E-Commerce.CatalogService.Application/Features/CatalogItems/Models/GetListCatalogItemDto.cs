namespace E_Commerce.CatalogService.Application.Features.CatalogItems.Models
{
    public class GetListCatalogItemDto
    {
        public uint Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required string CatalogBrandName { get; set; }
        public required string CatalogTypeName { get; set; }
        public IList<string>? CatalogItemsHeaderImages { get; set; }
    }
}
