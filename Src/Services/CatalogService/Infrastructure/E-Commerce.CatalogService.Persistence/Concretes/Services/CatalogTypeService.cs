using AutoMapper;
using E_Commerce.CatalogService.Application.Abstractions.Repositories;
using E_Commerce.CatalogService.Application.Abstractions.Services;
using E_Commerce.CatalogService.Application.Features.CatalogTypes.Models;
using E_Commerce.CatalogService.Application.Features.CatalogTypes.Rule;
using E_Commerce.CatalogService.Domain.Entities;

namespace E_Commerce.CatalogService.Persistence.Concretes.Services
{
    internal class CatalogTypeService : ICatalogTypeService
    {
        private readonly ICatalogTypeRepository _catalogTypeRepository;
        private readonly IMapper _mapper;
        public CatalogTypeService(ICatalogTypeRepository catalogTypeRepository, IMapper mapper)
        {
            _catalogTypeRepository = catalogTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCatalogTypeDto>> GetCatalogTypes()
        {
            var value = await _catalogTypeRepository.GetListAsync();
            return _mapper.ProjectTo<GetCatalogTypeDto>(value).ToList();
        }

        public async Task<GetCatalogTypeDto> GetCategoryById(uint id)
        {
            CatalogType? catalogType = await _catalogTypeRepository.GetAsync(x => x.Id == id);
            await catalogType.CannotNull("");
            return new()
            {
                Id = catalogType.Id,
                Name = catalogType.Name
            };
        }
    }
}
