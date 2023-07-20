using E_Commerce.IdentityService.Application.Features.Auth.Models;
using MediatR;

namespace E_Commerce.IdentityService.Application.Features.Admin.Command.CreateAdmin
{
    public class CreateAdminCommand : IRequest<bool>
    {
        public required RegisterDto RegisterDto { get; set; }

        public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, bool>
        {
            public Task<bool> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
            {
                //public async Task<bool> RegisterAdmin(RegisterDto registerDto)
                //{
                //    AppUser appUser = _mapper.Map<AppUser>(registerDto);
                //    await _userManager.AddToRoleAsync(appUser, "Admin");
                //    await CreateUser(appUser, registerDto.Password);
                //    return true;
                //}
                throw new NotImplementedException();
            }
        }
    }
}
