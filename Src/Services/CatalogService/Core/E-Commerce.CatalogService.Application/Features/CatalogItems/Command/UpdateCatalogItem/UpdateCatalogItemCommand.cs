using E_Commerce.CatalogService.Application.Abstractions.Services.CatalogItems;
using E_Commerce.CatalogService.Application.Features.CatalogItems.Models;
using E_Commerce.CatalogService.Application.Models;
using MediatR;

namespace E_Commerce.CatalogService.Application.Features.CatalogItems.Command.UpdateCatalogItem
{
    public class UpdateCatalogItemCommand : IRequest<ResponseDto<NoContent>>
    {
        public required UpdateCatalogItemDto UpdateCatalogItemDto { get; set; }
        public class UpdateCatalogItemCommandHandler : IRequestHandler<UpdateCatalogItemCommand, ResponseDto<NoContent>>
        {
            private readonly ICatalogItemWriteService _catalogItemsService;

            public UpdateCatalogItemCommandHandler(ICatalogItemWriteService catalogItemsService)
            {
                _catalogItemsService = catalogItemsService;
            }

            public async Task<ResponseDto<NoContent>> Handle(UpdateCatalogItemCommand request, CancellationToken cancellationToken)
            {
                await _catalogItemsService.UpdateProduct(request.UpdateCatalogItemDto);
                return ResponseDto<NoContent>.SuccessWithOutData("Ürün Güncellendi");
            }
        }
    }
}
