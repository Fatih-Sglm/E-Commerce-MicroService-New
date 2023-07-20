using AutoMapper;
using E_Commerce.CatalogService.Application.Abstractions.Repositories;
using E_Commerce.CatalogService.Application.Abstractions.Services;
using E_Commerce.CatalogService.Application.Features.CatalogBrands.Models;
using E_Commerce.CatalogService.Application.Features.CatalogBrands.Rules;
using E_Commerce.CatalogService.Domain.Entities;

namespace E_Commerce.CatalogService.Persistence.Concretes.Services
{
    public class CatalogBrandService : ICatalogBrandService
    {
        private readonly ICatalogBrandRepository _catalogBrandRepository;
        private readonly IMapper _mapper;
        public CatalogBrandService(ICatalogBrandRepository catalogBrandRepository, IMapper mapper)
        {
            _catalogBrandRepository = catalogBrandRepository;
            _mapper = mapper;
        }

        public async Task<CatalogBrand?> GetBrand(uint id)
        {
            return await _catalogBrandRepository.GetAsync(x => x.Id == id);
        }

        public async Task CheckBrandIsNull(uint id)
        {

            CatalogBrand? catalogBrand = await GetBrand(id);
            await catalogBrand!.CannotNull("");
        }

        public async Task<List<GetBrandDto>> GetBrands()
        {
            var value = await _catalogBrandRepository.GetListAsync();
            return _mapper.ProjectTo<GetBrandDto>(value).ToList();
        }
    }
}
