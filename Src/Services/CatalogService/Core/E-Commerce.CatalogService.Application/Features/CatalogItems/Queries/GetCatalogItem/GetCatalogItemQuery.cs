using E_Commerce.CatalogService.Application.Abstractions.Services.CatalogItems;
using E_Commerce.CatalogService.Application.Features.CatalogItems.Models;
using E_Commerce.CatalogService.Application.Models;
using MediatR;

namespace E_Commerce.CatalogService.Application.Features.CatalogItems.Queries.GetCatalogItem
{
    public class GetCatalogItemQuery : IRequest<ResponseDto<GetCatalogItemDto>>
    {
        public uint Id { get; set; }

        public class GetCatalogItemQueryHandler : IRequestHandler<GetCatalogItemQuery, ResponseDto<GetCatalogItemDto>>
        {
            private readonly ICatalogItemReadService _catalogItemsService;

            public GetCatalogItemQueryHandler(ICatalogItemReadService catalogItemsService)
            {
                _catalogItemsService = catalogItemsService;
            }

            public async Task<ResponseDto<GetCatalogItemDto>> Handle(GetCatalogItemQuery request, CancellationToken cancellationToken)
            {
                return ResponseDto<GetCatalogItemDto>.SuccessWithData(await _catalogItemsService.GetCatalogItem(request.Id));
            }
        }
    }
}
