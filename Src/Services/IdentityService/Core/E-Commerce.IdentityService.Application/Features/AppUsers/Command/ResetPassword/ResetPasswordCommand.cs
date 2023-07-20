using E_Commerce.IdentityService.Application.Abstractions.Services;
using E_Commerce.IdentityService.Application.Features.Auth.Constant;
using E_Commerce.IdentityService.Application.Models;
using MediatR;

namespace E_Commerce.IdentityService.Application.Features.AppUsers.Command.ResetPassword
{
    public class ResetPasswordCommand : IRequest<ResponseDto<NoContent>>
    {
        public required string Email { get; set; }
        public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ResponseDto<NoContent>>
        {
            private readonly IAppUserService _appUserService;

            public ResetPasswordCommandHandler(IAppUserService appUserService)
            {
                _appUserService = appUserService;
            }

            public async Task<ResponseDto<NoContent>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
            {

                await _appUserService.ResetPassword(request);
                return ResponseDto<NoContent>.SuccessWithOutData(AuthConstantMessage.WelcomeMessage);
            }
        }
    }
}
