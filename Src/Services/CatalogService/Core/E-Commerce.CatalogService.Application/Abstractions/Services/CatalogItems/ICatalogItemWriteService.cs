using E_Commerce.CatalogService.Application.Features.CatalogItems.Models;

namespace E_Commerce.CatalogService.Application.Abstractions.Services.CatalogItems
{
    public interface ICatalogItemWriteService
    {
        Task CreateProduct(CreateCatalogItemDto createCatalogItemDto);
        Task UpdateProduct(UpdateCatalogItemDto updateCatalogItemDto);
    }
}
