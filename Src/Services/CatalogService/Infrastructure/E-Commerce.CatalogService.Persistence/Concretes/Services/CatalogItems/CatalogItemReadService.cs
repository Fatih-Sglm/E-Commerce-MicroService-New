using AutoMapper;
using E_Commerce.CatalogService.Application.Abstractions.Repositories;
using E_Commerce.CatalogService.Application.Abstractions.Services;
using E_Commerce.CatalogService.Application.Abstractions.Services.CatalogItems;
using E_Commerce.CatalogService.Application.Features.CatalogItems.Models;
using E_Commerce.CatalogService.Application.Features.CatalogItems.Rules;
using E_Commerce.CatalogService.Application.Models.DynamicQuery;
using E_Commerce.CatalogService.Application.Paging;
using E_Commerce.CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_Commerce.CatalogService.Persistence.Concretes.Services.CatalogItems
{
    public class CatalogItemReadService : ICatalogItemReadService
    {
        private readonly ICatalogItemRepository _catalogItemRepository;
        private readonly IMapper _mapper;
        private readonly ICatalogItemImageService _catalogItemImageService;
        private readonly ICatalogTypeService _catalogTypeService;
        private readonly ICatalogBrandService _catalogBrandService;

        public CatalogItemReadService(ICatalogItemRepository catalogItemRepository,
            IMapper mapper, ICatalogItemImageService catalogItemImageService,
            ICatalogTypeService catalogTypeService, ICatalogBrandService catalogBrandService)
        {
            _catalogItemRepository = catalogItemRepository;
            _mapper = mapper;
            _catalogItemImageService = catalogItemImageService;
            _catalogTypeService = catalogTypeService;
            _catalogBrandService = catalogBrandService;
        }


        public async Task<GetCatalogItemDto> GetCatalogItem(uint CatalogItemId)
        {
            CatalogItem? catalogItem = await _catalogItemRepository.GetAsync(x => x!.Id! == CatalogItemId, include:
                    c => c.Include(x => x!.CatalogBrand!)!.Include(c => c!.CatalogType!)!.Include(x => x!.CatalogItemVariants!)!.Include(x => x!.CatalogItemImages!)!);

            await catalogItem.CannotNull("Böyle bir Ürün Bulunamadı");
            // _mapper.ProjectTo<GetCatalogItemDto>();
            GetCatalogItemDto getCatalogItemDto = _mapper.Map<GetCatalogItemDto>(catalogItem);
            getCatalogItemDto.CatalogItemsVariants = catalogItem!.CatalogItemVariants?.Select(x => x!.VariantName!).ToArray();
            getCatalogItemDto.CatalogItemsImagesPath = await _catalogItemImageService.GetCatalogItemImage(catalogItem);
            return getCatalogItemDto;
        }

        public async Task<CatalogItemListModel> GetListCatalogItem(PageRequest pageRequest)
        {
            return await GetListCatalogItemCondition(pageRequest);
        }

        public async Task<CatalogItemListModel> GetListCatalogItemByType(PageRequest pageRequest, uint catalogTypeId)
        {
            await _catalogTypeService.GetCategoryById(catalogTypeId);
            return await GetListCatalogItemCondition(pageRequest, x => x!.CatalogType.Id! == catalogTypeId);
        }

        public async Task<CatalogItemListModel> GetListCatalogItemByBrand(PageRequest pageRequest, uint brandId)
        {
            await _catalogBrandService.CheckBrandIsNull(brandId);
            return await GetListCatalogItemCondition(pageRequest, x => x!.CatalogBrand.Id! == brandId);
        }

        public async Task<CatalogItemListModel> GetListCatalogItemDynamic(Dynamic dynamic, PageRequest pageRequest)
        {
            return await GetListCatalogItemConditionDynamic(dynamic, pageRequest);
        }




        private async Task<CatalogItemListModel> GetListCatalogItemConditionDynamic(Dynamic dynamic, PageRequest pageRequest, Expression<Func<CatalogItem, bool>>? predicate = null)
        {

            IPaginate<CatalogItem>? catalogItems = await _catalogItemRepository.GetListDynamicAsyncWithPaginate(dynamic, predicate, index: pageRequest!.Page!, size: pageRequest!.PageSize!,
            include: c => c.Include(c => c!.CatalogBrand!).Include(c => c!.CatalogType!).Include(c => c!.CatalogItemImages!).
            Include(c => c!.CatalogItemVariants!)!);


            CatalogItemListModel catalogItemListModel = _mapper.Map<CatalogItemListModel>(catalogItems);
            foreach (var item in catalogItemListModel!.Items!)
            {
                item.CatalogItemsHeaderImages = await _catalogItemImageService.GetCatalogItemImageWithList(catalogItems!.Items!.Where(x => x!.Id! == item!.Id!).SelectMany(x => x!.CatalogItemImages!).Where(x => x!.IsHeader! == true).ToArray());
            }
            return catalogItemListModel;
        }

        private async Task<CatalogItemListModel> GetListCatalogItemCondition(PageRequest pageRequest, Expression<Func<CatalogItem, bool>>? predicate = null)
        {

            IPaginate<CatalogItem>? catalogItems = await _catalogItemRepository.
            GetListAsyncWithPaginate(predicate, index: pageRequest!.Page!, size: pageRequest!.PageSize!,
            include: c => c.Include(c => c!.CatalogBrand!).Include(c => c!.CatalogType!).Include(c => c!.CatalogItemImages!).Include(c => c!.CatalogItemVariants!)!, orderBy: x => x.OrderByDescending(x => x!.CatalogBrand!.Name));
            CatalogItemListModel catalogItemListModel = _mapper.Map<CatalogItemListModel>(catalogItems);
            foreach (var item in catalogItemListModel!.Items!)
            {
                item.CatalogItemsHeaderImages = await _catalogItemImageService.GetCatalogItemImageWithList(catalogItems!.Items!.Where(x => x!.Id! == item!.Id!).SelectMany(x => x!.CatalogItemImages!).Where(x => x!.IsHeader! == true).ToArray());
            }
            return catalogItemListModel;
        }

    }
}
