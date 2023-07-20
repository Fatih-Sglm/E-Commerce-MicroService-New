namespace E_Commerce.CatalogService.Application.Features.CatalogItemPicture.Models
{
    public class GetCatalogItemImageDto
    {
        public uint Id { get; set; }
        public required string Path { get; set; }

        public uint CatalogItemId { get; set; }
    }
}
