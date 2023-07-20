using AutoMapper;
using E_Commerce.CatalogService.Application.Abstractions.Repositories;
using E_Commerce.CatalogService.Application.Abstractions.Services;
using E_Commerce.CatalogService.Application.Abstractions.Services.CatalogItems;
using E_Commerce.CatalogService.Application.Features.CatalogItems.Models;
using E_Commerce.CatalogService.Application.Features.CatalogItems.Rules;
using E_Commerce.CatalogService.Domain.Entities;

namespace E_Commerce.CatalogService.Persistence.Concretes.Services.CatalogItems
{
    public class CatalogItemWriteService : ICatalogItemWriteService
    {
        private readonly ICatalogItemRepository _catalogItemRepository;
        private readonly IMapper _mapper;
        private readonly ICatalogItemImageService _catalogItemImageService;
        private readonly ICatalogItemVariantService _catalogItemVariantService;

        public CatalogItemWriteService(ICatalogItemRepository catalogItemRepository,
            IMapper mapper, ICatalogItemImageService catalogItemImageService,
            ICatalogItemVariantService catalogItemVariantService)
        {
            _catalogItemRepository = catalogItemRepository;
            _mapper = mapper;
            _catalogItemImageService = catalogItemImageService;
            _catalogItemVariantService = catalogItemVariantService;
        }

        public async Task CreateProduct(CreateCatalogItemDto createCatalogItemDto)
        {
            CatalogItem catalogItem = _mapper.Map<CatalogItem>(createCatalogItemDto);
            await SetCatalogItemVariant(catalogItem, createCatalogItemDto.Variants);
            catalogItem.CatalogItemImages = await _catalogItemImageService.CreateCatalogItemImage(catalogItem, createCatalogItemDto.FolderPath, createCatalogItemDto.Images!);
            await _catalogItemRepository.AddAsync(catalogItem);
            await _catalogItemRepository.SaveChangesAsync();
        }

        public async Task UpdateProduct(UpdateCatalogItemDto updateCatalogItemDto)
        {
            CatalogItem? catalogItem = await _catalogItemRepository.GetAsync(x => x.Id == updateCatalogItemDto.Id);
            await catalogItem.CannotNull("Ürün Null Olamaz");
            //catalogItem!.CatalogItemFeature = _mapper.Map<CatalogItemFeature>(updateCatalogItemDto.createCatalogItemFeaturesDto);
            //await _catalogItemImageService.CreateCatalogItemImage(updateCatalogItemDto.Id, updateCatalogItemDto.createCatalogItemDto.ImagesPath!);
            await _catalogItemRepository.UpdateAsync(catalogItem!);
        }

        private async Task SetCatalogItemVariant(CatalogItem catalogItem, IList<uint>? variants)
        {
            if (variants is not null)
            {
                foreach (var item in variants)
                {
                    CatalogItemVariant catalogItemVariant = await _catalogItemVariantService.GetCatalogItemVariant(item);
                    catalogItem.CatalogItemVariants?.Add(catalogItemVariant);
                }
            }
            return;
        }
    }
}
