using E_Commerce.CatalogService.Application.Abstractions.Repositories;
using E_Commerce.CatalogService.Application.Models;
using E_Commerce.CatalogService.Domain.Entities;
using MediatR;

namespace E_Commerce.CatalogService.Application.Features.CatalogItems.Command.DeleteCatalogItem
{
    public class DeleteCatalogItemCommand : IRequest<ResponseDto<NoContent>>
    {
        public int Id { get; set; }


        public class DeleteCatalogItemCommandHandler : IRequestHandler<DeleteCatalogItemCommand, ResponseDto<NoContent>>
        {
            private readonly ICatalogItemRepository _catalogItemRepository;

            public DeleteCatalogItemCommandHandler(ICatalogItemRepository catalogItemRepository)
            {
                _catalogItemRepository = catalogItemRepository;
            }

            public async Task<ResponseDto<NoContent>> Handle(DeleteCatalogItemCommand request, CancellationToken cancellationToken)
            {
                CatalogItem? catalogItem = await _catalogItemRepository.GetAsync(x => x.Id == request.Id);
                await _catalogItemRepository.DeleteAsync(catalogItem!);
                return ResponseDto<NoContent>.SuccessWithOutData("Ürün Silme Başarılı");
            }
        }
    }
}
