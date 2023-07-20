using E_Commerce.CatalogService.Domain.Entities;

namespace E_Commerce.CatalogService.Application.Abstractions.Services
{
    public interface ICatalogItemVariantService
    {
        //Task CreateCatalogItemVariant(IList<uint> variant);
        Task<CatalogItemVariant> GetCatalogItemVariant(uint id);
    }
}