using E_Commerce.CatalogService.Application.Abstractions.Services;
using MediatR;

namespace E_Commerce.CatalogService.Application.Features.CatalogItemPicture.Queries.GetCatalogItemImage
{
    public class GetCatalogItemImageCommand : IRequest<bool>
    {
        public uint CatalogItemId { get; set; }

        public class GetCatalogItemImageCommandHandler : IRequestHandler<GetCatalogItemImageCommand, bool>
        {
            private readonly ICatalogItemImageService _catalogItemImageService;

            public GetCatalogItemImageCommandHandler(ICatalogItemImageService catalogItemImageService)
            {
                _catalogItemImageService = catalogItemImageService;
            }

            public Task<bool> Handle(GetCatalogItemImageCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
