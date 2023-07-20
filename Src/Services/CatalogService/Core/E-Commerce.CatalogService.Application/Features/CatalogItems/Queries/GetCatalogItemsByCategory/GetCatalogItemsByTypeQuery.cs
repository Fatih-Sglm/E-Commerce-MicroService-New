using E_Commerce.CatalogService.Application.Abstractions.Services.CatalogItems;
using E_Commerce.CatalogService.Application.Features.CatalogItems.Models;
using E_Commerce.CatalogService.Application.Models;
using E_Commerce.CatalogService.Application.Paging;
using MediatR;

namespace E_Commerce.CatalogService.Application.Features.CatalogItems.Queries.GetCatalogItemsByCategory
{
    public class GetCatalogItemsByTypeQuery : IRequest<ResponseDto<CatalogItemListModel>>
    {
        public PageRequest PageRequest { get; set; } = new PageRequest(0, 5);
        public uint CategoryId { get; set; }

        public class GetCatalogItemsByTypeQueryHandler : IRequestHandler<GetCatalogItemsByTypeQuery, ResponseDto<CatalogItemListModel>>
        {
            private readonly ICatalogItemReadService _catalogItemsService;

            public GetCatalogItemsByTypeQueryHandler(ICatalogItemReadService catalogItemsService)
            {
                _catalogItemsService = catalogItemsService;
            }

            public async Task<ResponseDto<CatalogItemListModel>> Handle(GetCatalogItemsByTypeQuery request, CancellationToken cancellationToken)
            {
                CatalogItemListModel? model = await _catalogItemsService.GetListCatalogItemByType(request.PageRequest, request.CategoryId);
                return ResponseDto<CatalogItemListModel>.SuccessWithData(model);
            }
        }
    }
}
