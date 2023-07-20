using E_Commerce.IdentityService.Application.Abstractions.Services.AuthService;
using E_Commerce.IdentityService.Application.Features.Auth.Models;
using MediatR;

namespace E_Commerce.IdentityService.Application.Features.Auth.Command.Login.User
{
    public class LoginUserCommand : IRequest<LoginResponseDto>
    {
        public required string UserNameOrEmail { get; set; }
        public required string Password { get; set; }
        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponseDto>
        {
            private readonly IAuthService _authService;

            public LoginUserCommandHandler(IAuthService authService)
            {
                _authService = authService;
            }

            public async Task<LoginResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var reponse = await _authService.LoginAsync(request);
                return reponse;
            }
        }
    }
}
