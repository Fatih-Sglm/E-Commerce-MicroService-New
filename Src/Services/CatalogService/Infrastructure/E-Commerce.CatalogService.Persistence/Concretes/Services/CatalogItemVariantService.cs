using E_Commerce.CatalogService.Application.Abstractions.Repositories;
using E_Commerce.CatalogService.Application.Abstractions.Services;
using E_Commerce.CatalogService.Domain.Entities;

namespace E_Commerce.CatalogService.Persistence.Concretes.Services
{
    public class CatalogItemVariantService : ICatalogItemVariantService
    {
        private readonly ICatalogItemVariantRepository _catalogItemVariantRepository;

        public CatalogItemVariantService(ICatalogItemVariantRepository catalogItemVariantRepository)
        {
            _catalogItemVariantRepository = catalogItemVariantRepository;
        }

        public async Task<CatalogItemVariant> GetCatalogItemVariant(uint id)
        {
            CatalogItemVariant? catalogItemVariant = await _catalogItemVariantRepository.GetAsync(x => x.Id == id);
            return catalogItemVariant;
        }
    }
}
