using E_Commerce.IdentityService.Application.Abstractions.Services;
using E_Commerce.IdentityService.Application.Exceptions;
using E_Commerce.IdentityService.Application.Features.AppUsers.Command.VerifyEmail;
using E_Commerce.IdentityService.Application.Features.AppUsers.Command.VerifyResetPassword;
using E_Commerce.IdentityService.Application.Features.Auth.Rules;
using E_Commerce.IdentityService.Application.Helper;
using E_Commerce.IdentityService.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.IdentityService.Persistence.Concretes.Services
{
    public class VerifyService : IVeriyService
    {
        private readonly UserManager<AppUser> _userManager;

        public VerifyService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task VerifyEmailAddress(VerifyEmailCommand command)
        {
            AppUser? appUser = await _userManager.FindByIdAsync(command.UserId);
            appUser?.CheckUserIsNull();

            var result = await _userManager.VerifyIdentityToken(appUser!, command.Token, VerifyTokenOption.EmailConfirmed);
            if (!result.Item1)
                throw new IdentityException("Lütfen Geçerli bir Url Kullanınız");
            appUser!.EmailConfirmed = true;
            await _userManager.UpdateAsync(appUser);
            await _userManager.UpdateSecurityStampAsync(appUser);

        }

        public async Task<string> VerifyResetPassword(VerifyResetPasswordCommand command)
        {
            AppUser? appUser = await _userManager.FindByIdAsync(command.UserId);
            appUser?.CheckUserIsNull();
            var result = await _userManager.VerifyIdentityToken(appUser!, command.Token, VerifyTokenOption.ResetPassword);
            if (!result.Item1)
                throw new IdentityException("Lütfen Geçerli bir Url Kullanınız");

            return result.Item2;
        }
    }
}
