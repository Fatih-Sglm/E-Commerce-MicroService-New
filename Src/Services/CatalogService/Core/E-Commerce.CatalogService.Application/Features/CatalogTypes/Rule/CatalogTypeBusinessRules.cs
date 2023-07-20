using E_Commerce.CatalogService.Domain.Entities;

namespace E_Commerce.CatalogService.Application.Features.CatalogTypes.Rule
{
    public static class CatalogTypeBusinessRules
    {
        public static Task CannotNull(this CatalogType catalogType, string message)
        {
            if (catalogType is null)
            {
                throw new Exception(message);
            }
            return Task.CompletedTask;
        }
    }
}
