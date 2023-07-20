using E_Commerce.CatalogService.Application.Abstractions.Repositories;
using E_Commerce.CatalogService.Domain.Entities;
using E_Commerce.CatalogService.Persistence.Concretes.Repositories.GenericRepo;
using E_Commerce.CatalogService.Persistence.Context;

namespace E_Commerce.CatalogService.Persistence.Concretes.Repositories
{
    public class CatalogBrandRepository : GenericRepository<CatalogBrand, CatalogContext>, ICatalogBrandRepository
    {
        public CatalogBrandRepository(CatalogContext context) : base(context)
        {
        }
    }
}
