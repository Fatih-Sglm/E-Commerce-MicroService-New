using E_Commerce.IdentityService.Application.Abstractions.Services.AuthService;
using E_Commerce.IdentityService.Application.Models;
using MediatR;

namespace E_Commerce.IdentityService.Application.Features.Auth.Command.Register
{
    public class RegisterUserCommand : IRequest<ResponseDto<NoContent>>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ResponseDto<NoContent>>
        {
            private readonly IAuthService _authService;

            public RegisterUserCommandHandler(IAuthService authService)
            {
                _authService = authService;
            }

            public async Task<ResponseDto<NoContent>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                return ResponseDto<NoContent>.SuccessWithOutData(await _authService.Register(request));
            }
        }
    }
}
