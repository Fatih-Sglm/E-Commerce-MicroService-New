using E_Commerce.CatalogService.Application.Abstractions.Repositories;
using E_Commerce.CatalogService.Application.Features.CatalogBrands.Rules;
using E_Commerce.CatalogService.Application.Models;
using MediatR;

namespace E_Commerce.CatalogService.Application.Features.CatalogBrands.Commands.CreateCatalogBrand
{
    public class CreateCatalogBrandCommand : IRequest<ResponseDto<NoContent>>
    {
        public required string Name { get; set; }


        public class CreateCatalogBrandCommandHandler : IRequestHandler<CreateCatalogBrandCommand, ResponseDto<NoContent>>
        {
            private readonly ICatalogBrandRepository _catalogBrandRepository;


            public CreateCatalogBrandCommandHandler(ICatalogBrandRepository catalogBrandRepository)
            {
                _catalogBrandRepository = catalogBrandRepository;
            }

            public async Task<ResponseDto<NoContent>> Handle(CreateCatalogBrandCommand request, CancellationToken cancellationToken)
            {
                await _catalogBrandRepository.CannotDuplicate(request.Name, "");
                await _catalogBrandRepository.AddAsync(new() { Name = request.Name });
                return ResponseDto<NoContent>.SuccessWithOutData("");
            }
        }
    }

}
