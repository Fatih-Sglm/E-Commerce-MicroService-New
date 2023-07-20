using E_Commerce.IdentityService.Application.Abstractions.Services.AuthService;
using E_Commerce.IdentityService.Application.Features.Auth.Models;
using E_Commerce.IdentityService.Application.Models;
using MediatR;

namespace E_Commerce.IdentityService.Application.Features.Auth.Command.Login.RefreshTokenLogin
{
    public class RefreshTokenLoginCommand : IRequest<ResponseDto<LoginResponseDto>>
    {
        public required string RefreshToken { get; set; }

        public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommand, ResponseDto<LoginResponseDto>>
        {
            private readonly IAuthService _authService;

            public RefreshTokenLoginCommandHandler(IAuthService authService)
            {
                _authService = authService;
            }

            public async Task<ResponseDto<LoginResponseDto>> Handle(RefreshTokenLoginCommand request, CancellationToken cancellationToken)
            {
                var value = await _authService.RefreshTokenLoginAsync(request.RefreshToken);
                return ResponseDto<LoginResponseDto>.SuccessWithData(value);
            }
        }
    }
}
