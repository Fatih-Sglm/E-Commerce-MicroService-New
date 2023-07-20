using E_Commerce.CatalogService.Application.Abstractions.Repositories;
using E_Commerce.CatalogService.Domain.Entities;

namespace E_Commerce.CatalogService.Application.Features.CatalogBrands.Rules
{
    public static class CatalogBrandBusinessRules
    {

        public static Task CannotNull(this CatalogBrand item, string errorMessage)
        {
            if (item is null) throw new Exception(errorMessage);
            return Task.CompletedTask;
        }
        public static async Task CannotDuplicate(this ICatalogBrandRepository brandRepository, string brandName, string errorMessage)
        {
            var result = await brandRepository.GetListAsync(b => b.Name == brandName);
            if (result.Any()) throw new Exception(errorMessage);
        }
    }
}
