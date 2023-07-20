using E_Commerce.CatalogService.Application.Features.CatalogTypes.Models;

namespace E_Commerce.CatalogService.Application.Abstractions.Services
{
    public interface ICatalogTypeService
    {
        Task<GetCatalogTypeDto> GetCategoryById(uint id);
        Task<List<GetCatalogTypeDto>> GetCatalogTypes();
    }
}
