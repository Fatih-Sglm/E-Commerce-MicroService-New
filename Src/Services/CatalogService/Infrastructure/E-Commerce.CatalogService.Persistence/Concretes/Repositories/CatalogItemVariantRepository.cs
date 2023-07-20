using E_Commerce.CatalogService.Application.Abstractions.Repositories;
using E_Commerce.CatalogService.Domain.Entities;
using E_Commerce.CatalogService.Persistence.Concretes.Repositories.GenericRepo;
using E_Commerce.CatalogService.Persistence.Context;

namespace E_Commerce.CatalogService.Persistence.Concretes.Repositories
{
    public class CatalogItemVariantRepository : GenericRepository<CatalogItemVariant, CatalogContext>, ICatalogItemVariantRepository
    {
        public CatalogItemVariantRepository(CatalogContext context) : base(context)
        {
        }
    }
}
