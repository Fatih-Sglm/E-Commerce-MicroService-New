using E_Commerce.CatalogService.Application.Paging;

namespace E_Commerce.CatalogService.Application.Features.CatalogItems.Models
{
    public class CatalogItemListModel : BasePageableModel
    {
        public IList<GetListCatalogItemDto> Items { get; set; } = new List<GetListCatalogItemDto>();
    }
}
