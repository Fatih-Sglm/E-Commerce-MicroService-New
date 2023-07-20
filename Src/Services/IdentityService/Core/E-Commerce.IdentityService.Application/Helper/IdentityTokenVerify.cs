using E_Commerce.IdentityService.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.IdentityService.Application.Helper
{
    public static class IdentityTokenVerify
    {


        public static async Task<(bool, string)> VerifyIdentityToken(this UserManager<AppUser> userManager, AppUser appUser, string token, VerifyTokenOption option)
        {
            token = token.UrlDecode();
            return option switch
            {
                VerifyTokenOption.EmailConfirmed => (await userManager.VerifyUserTokenAsync(appUser,
                                         userManager.Options.Tokens.EmailConfirmationTokenProvider, "EmailConfirmation", token), token),
                VerifyTokenOption.ResetPassword => (await userManager.VerifyUserTokenAsync(appUser,
                                         userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", token), token),
                _ => throw new Exception(),
            };
        }
    }
    public enum VerifyTokenOption
    {
        EmailConfirmed,
        ResetPassword,
    }
}
