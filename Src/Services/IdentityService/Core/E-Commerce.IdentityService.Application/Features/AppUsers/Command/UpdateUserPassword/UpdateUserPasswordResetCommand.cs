using E_Commerce.IdentityService.Application.Abstractions.Services;
using E_Commerce.IdentityService.Application.Models;
using MediatR;

namespace E_Commerce.IdentityService.Application.Features.AppUsers.Command.UpdateUserPassword
{
    public class UpdateUserPasswordResetCommand : IRequest<ResponseDto<NoContent>>
    {
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }

        public required string ResetToken { get; set; }
        public required string UserId { get; set; }
        public class UpdateUserPasswordResetCommandHandler : IRequestHandler<UpdateUserPasswordResetCommand, ResponseDto<NoContent>>
        {
            private readonly IAppUserService _appUserService;

            public UpdateUserPasswordResetCommandHandler(IAppUserService appUserService)
            {
                _appUserService = appUserService;
            }

            public async Task<ResponseDto<NoContent>> Handle(UpdateUserPasswordResetCommand request, CancellationToken cancellationToken)
            {
                await _appUserService.UpdatePassword(request);
                return ResponseDto<NoContent>.SuccessWithOutData("Şifreniz Başarılı bir şekilde Güncellendi");
            }
        }
    }
}
