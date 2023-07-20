using E_Commerce.IdentityService.Application.Abstractions.Services;
using E_Commerce.IdentityService.Application.Models;
using MediatR;

namespace E_Commerce.IdentityService.Application.Features.AppUsers.Command.VerifyResetPassword
{
    public class VerifyResetPasswordCommand : IRequest<ResponseDto<NoContent>>
    {
        public required string Token { get; set; }
        public required string UserId { get; set; }

        public class VerifyResetPasswordCommandHandler : IRequestHandler<VerifyResetPasswordCommand, ResponseDto<NoContent>>
        {
            private readonly IVeriyService _verifyService;

            public VerifyResetPasswordCommandHandler(IVeriyService verifyService)
            {
                _verifyService = verifyService;
            }

            public async Task<ResponseDto<NoContent>> Handle(VerifyResetPasswordCommand request, CancellationToken cancellationToken)
            {
                await _verifyService.VerifyResetPassword(request);
                return ResponseDto<NoContent>.SuccessWithOutData("True");
            }

        }
    }
}
