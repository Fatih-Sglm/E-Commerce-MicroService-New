using E_Commerce.IdentityService.Application.Abstractions.Services;
using E_Commerce.IdentityService.Application.Features.Auth.Constant;
using MediatR;

namespace E_Commerce.IdentityService.Application.Features.AppUsers.Command.CreateUser
{
    public class CreateUserCommand : IRequest<string>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }

        public class CreateUserCommandCommandHandler : IRequestHandler<CreateUserCommand, string>
        {
            private readonly IAppUserService _appUserService;

            public CreateUserCommandCommandHandler(IAppUserService appUserService)
            {
                _appUserService = appUserService;
            }

            public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                await _appUserService.CreateUser(request);
                return AuthConstantMessage.WelcomeMessage;
            }
        }
    }
}
