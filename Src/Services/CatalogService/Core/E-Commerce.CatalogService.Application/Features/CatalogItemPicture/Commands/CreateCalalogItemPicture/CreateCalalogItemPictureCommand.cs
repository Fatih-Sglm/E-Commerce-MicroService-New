//using E_Commerce.CatalogService.Application.Abstractions.Services;
//using E_Commerce.CatalogService.Application.Features.Common;
//using MediatR;
//using Microsoft.AspNetCore.Http;

//namespace E_Commerce.CatalogService.Application.Features.CatalogItemPicture.Commands.CreateCalalogItemPicture
//{
//    public class CreateCalalogItemPictureCommand : IRequest<ResponseDto<NoContent>>
//    {
//        public IFormFileCollection? FormFiles { get; set; }


//        public class CreateCalalogItemPictureCommandHandler : IRequestHandler<CreateCalalogItemPictureCommand, ResponseDto<NoContent>>
//        {
//            private readonly ICatalogItemImageService _catalogItemImageService;

//            public CreateCalalogItemPictureCommandHandler(ICatalogItemImageService catalogItemImageService)
//            {
//                _catalogItemImageService = catalogItemImageService;
//            }

//            public Task<ResponseDto<NoContent>> Handle(CreateCalalogItemPictureCommand request, CancellationToken cancellationToken)
//            {
//                //_catalogItemImageService.CreateCatalogItemImage();
//                throw new NotImplementedException();
//            }
//        }
//    }
//}
