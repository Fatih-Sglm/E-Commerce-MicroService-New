using E_Commerce.IdentityService.Application.Features.AppUsers.Command.VerifyEmail;
using E_Commerce.IdentityService.Application.Features.AppUsers.Command.VerifyResetPassword;

namespace E_Commerce.IdentityService.Application.Abstractions.Services
{
    public interface IVeriyService
    {
        Task VerifyEmailAddress(VerifyEmailCommand command);
        Task<string> VerifyResetPassword(VerifyResetPasswordCommand command);
    }
}
