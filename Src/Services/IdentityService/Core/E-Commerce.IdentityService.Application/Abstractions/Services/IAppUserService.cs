using E_Commerce.IdentityService.Application.Features.AppUsers.Command.CreateUser;
using E_Commerce.IdentityService.Application.Features.AppUsers.Command.ResetPassword;
using E_Commerce.IdentityService.Application.Features.AppUsers.Command.UpdateUserPassword;

namespace E_Commerce.IdentityService.Application.Abstractions.Services
{
    public interface IAppUserService
    {
        Task CreateUser(CreateUserCommand request);
        Task ResetPassword(ResetPasswordCommand command);
        Task UpdatePassword(UpdateUserPasswordResetCommand command);
    }
}
