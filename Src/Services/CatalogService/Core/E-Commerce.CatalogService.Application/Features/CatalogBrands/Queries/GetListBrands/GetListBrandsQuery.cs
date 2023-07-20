//using E_Commerce.CatalogService.Application.Abstractions.Services;
//using E_Commerce.CatalogService.Application.Features.CatalogBrands.Dtos;
//using MediatR;

//namespace E_Commerce.CatalogService.Application.Features.CatalogBrands.Queries.GetListBrands
//{
//    public class GetListBrandsQuery : IRequest<List<GetBrandDto>>
//    {
//        public class GetListBrandsQueryHandler : IRequestHandler<GetListBrandsQuery, List<GetBrandDto>>
//        {
//            private readonly ICatalogBrandService _catalogBrandService;

//            public GetListBrandsQueryHandler(ICatalogBrandService catalogBrandService)
//            {
//                _catalogBrandService = catalogBrandService;
//            }

//            public async Task<List<GetBrandDto>> Handle(GetListBrandsQuery request, CancellationToken cancellationToken)
//            {
//                return
//            }
//        }
//    }
//}
