using E_Commerce.CatalogService.Application.Abstractions.Repositories;
using E_Commerce.CatalogService.Application.Features.CatalogBrands.Rules;
using E_Commerce.CatalogService.Application.Models;
using E_Commerce.CatalogService.Domain.Entities;
using MediatR;

namespace E_Commerce.CatalogService.Application.Features.CatalogBrands.Commands.UpdateCatalogBrand
{
    public class UpdateCatalogBrandCommand : IRequest<ResponseDto<NoContent>>
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public class UpdateCatalogBrandCommandHandler : IRequestHandler<UpdateCatalogBrandCommand, ResponseDto<NoContent>>
        {
            private readonly ICatalogBrandRepository _catalogBrandRepository;

            public UpdateCatalogBrandCommandHandler(ICatalogBrandRepository catalogBrandRepository)
            {
                _catalogBrandRepository = catalogBrandRepository;
            }

            public async Task<ResponseDto<NoContent>> Handle(UpdateCatalogBrandCommand request, CancellationToken cancellationToken)
            {
                CatalogBrand? catalogBrand = await _catalogBrandRepository.GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
                await catalogBrand.CannotNull("");
                await _catalogBrandRepository.CannotDuplicate(request.Name, "");
                return ResponseDto<NoContent>.SuccessWithOutData("");
            }
        }
    }
}
