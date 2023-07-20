using E_Commerce.CatalogService.Application.Features.CatalogItems.Models;
using E_Commerce.CatalogService.Application.Models.DynamicQuery;
using E_Commerce.CatalogService.Application.Paging;

namespace E_Commerce.CatalogService.Application.Abstractions.Services.CatalogItems
{
    public interface ICatalogItemReadService
    {
        Task<GetCatalogItemDto> GetCatalogItem(uint CatalogItemId);

        Task<CatalogItemListModel> GetListCatalogItem(PageRequest pageRequest);

        Task<CatalogItemListModel> GetListCatalogItemDynamic(Dynamic dynamic, PageRequest pageRequest);

        Task<CatalogItemListModel> GetListCatalogItemByType(PageRequest pageRequest, uint catalogTypeId);

        Task<CatalogItemListModel> GetListCatalogItemByBrand(PageRequest pageRequest, uint brandId);
    }
}
