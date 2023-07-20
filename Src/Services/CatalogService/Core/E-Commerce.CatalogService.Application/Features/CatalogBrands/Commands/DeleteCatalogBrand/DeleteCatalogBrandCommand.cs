using E_Commerce.CatalogService.Application.Abstractions.Repositories;
using E_Commerce.CatalogService.Application.Features.CatalogBrands.Rules;
using E_Commerce.CatalogService.Application.Models;
using E_Commerce.CatalogService.Domain.Entities;
using MediatR;

namespace E_Commerce.CatalogService.Application.Features.CatalogBrands.Commands.DeleteCatalogBrand
{
    public class DeleteCatalogBrandCommand : IRequest<ResponseDto<NoContent>>
    {
        public uint Id { get; set; }

        public class DeleteCatalogBrandCommandHandler : IRequestHandler<DeleteCatalogBrandCommand, ResponseDto<NoContent>>
        {
            private readonly ICatalogBrandRepository _catalogBrandRepository;

            public DeleteCatalogBrandCommandHandler(ICatalogBrandRepository catalogBrandRepository)
            {
                _catalogBrandRepository = catalogBrandRepository;
            }

            public async Task<ResponseDto<NoContent>> Handle(DeleteCatalogBrandCommand request, CancellationToken cancellationToken)
            {
                CatalogBrand? catalogBrand = await _catalogBrandRepository.GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
                await catalogBrand.CannotNull("");
                await _catalogBrandRepository.DeleteAsync(catalogBrand);
                return ResponseDto<NoContent>.SuccessWithOutData("");
            }
        }
    }

}
