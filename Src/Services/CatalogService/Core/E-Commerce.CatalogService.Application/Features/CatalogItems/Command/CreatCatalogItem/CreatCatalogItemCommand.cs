using E_Commerce.CatalogService.Application.Abstractions.Services.CatalogItems;
using E_Commerce.CatalogService.Application.Features.CatalogItems.Models;
using E_Commerce.CatalogService.Application.Models;
using MediatR;

namespace E_Commerce.CatalogService.Application.Features.CatalogItems.Command.CreatCatalogItem
{
    public class CreatCatalogItemCommand : CreateCatalogItemDto, IRequest<ResponseDto<NoContent>>
    {
        public class CreatCatalogItemCommandHandler : IRequestHandler<CreatCatalogItemCommand, ResponseDto<NoContent>>
        {
            private readonly ICatalogItemWriteService _catalogItemsService;
            public CreatCatalogItemCommandHandler(ICatalogItemWriteService catalogItemsService)
            {
                _catalogItemsService = catalogItemsService;
            }

            public async Task<ResponseDto<NoContent>> Handle(CreatCatalogItemCommand request, CancellationToken cancellationToken)
            {
                await _catalogItemsService.CreateProduct(request);
                return ResponseDto<NoContent>.SuccessWithOutData("ürün Eklendi");
            }
        }
    }
}
