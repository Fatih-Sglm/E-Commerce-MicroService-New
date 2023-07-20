using E_Commerce.IdentityService.Application.Abstractions.Services;
using E_Commerce.IdentityService.Application.Features.AppUsers.Constant;
using E_Commerce.IdentityService.Application.Models;
using MediatR;

namespace E_Commerce.IdentityService.Application.Features.AppUsers.Command.VerifyEmail
{
    public class VerifyEmailCommand : IRequest<ResponseDto<NoContent>>
    {
        public required string Token { get; set; }
        public required string UserId { get; set; }
        public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand, ResponseDto<NoContent>>
        {
            private readonly IVeriyService _verifyService;

            public VerifyEmailCommandHandler(IVeriyService verifyService)
            {
                _verifyService = verifyService;
            }

            public async Task<ResponseDto<NoContent>> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
            {
                await _verifyService.VerifyEmailAddress(request);
                return ResponseDto<NoContent>.SuccessWithOutData(AppUserConstant.EmailConfirmSuccesfully);
            }
        }

    }
}