using E_Commerce.IdentityService.Application.Abstractions.Services;
using E_Commerce.IdentityService.Application.Abstractions.Services.AuthService;
using E_Commerce.IdentityService.Application.Abstractions.Services.Jwt;
using E_Commerce.IdentityService.Application.Features.Auth.Command.Login.User;
using E_Commerce.IdentityService.Application.Features.Auth.Command.Register;
using E_Commerce.IdentityService.Application.Features.Auth.Constant;
using E_Commerce.IdentityService.Application.Features.Auth.Models;
using E_Commerce.IdentityService.Application.Features.Auth.Rules;
using E_Commerce.IdentityService.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.IdentityService.Persistence.Concretes.Services
{
    public class AuthService : IAuthService
    {

        private readonly ITokenHelper _tokenHandler;
        private readonly UserManager<AppUser> _userManager;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IAppUserService _appUserService;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthService(ITokenHelper tokenHandler,
            UserManager<AppUser> userManager,
            IRefreshTokenService refreshTokenService,
            SignInManager<AppUser> signInManager,
            IAppUserService appUserService)
        {
            _tokenHandler = tokenHandler;
            _userManager = userManager;
            _refreshTokenService = refreshTokenService;
            _signInManager = signInManager;
            _appUserService = appUserService;
        }
        public async Task<LoginResponseDto> LoginAsync(LoginUserCommand command)
        {
            AppUser? user = await _userManager.FindByEmailAsync(command.UserNameOrEmail);
            user ??= await _userManager.FindByNameAsync(command.UserNameOrEmail);
            // Created extension method for those functions
            await user.CheckUserIsNull();
            await _userManager.CheckEmailConfirmed(user!);
            await _signInManager.CheckUserPassword(user!, command.Password);
            return await GenerateAccessToken(user!);
        }

        private async Task<LoginResponseDto> GenerateAccessToken(AppUser user)
        {
            AccessToken accessToken = _tokenHandler.CreateToken(user!, await _userManager.GetRolesAsync(user));
            string refreshToken = _tokenHandler.CreateRefreshToken();
            await _refreshTokenService.InsertRefreshToken(user, refreshToken, accessToken.Expiration.AddDays(1));

            return new()
            {
                Token = accessToken.Token,
                RefreshToken = refreshToken,
            };
        }

        public async Task<LoginResponseDto> RefreshTokenLoginAsync(string refreshToken)
        {
            var userRefreshToken = await _refreshTokenService.GetRefreshTokenByToken(refreshToken);
            return await GenerateAccessToken(userRefreshToken!.User);
        }

        public Task<LoginResponseDto> FacebookLoginAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LoginResponseDto> GoogleLoginAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> Register(RegisterUserCommand command)
        {
            await _appUserService.CreateUser(new()
            {
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Password = command.Password,
                UserName = command.UserName,
            });

            return AuthConstantMessage.WelcomeMessage;
        }
    }
}
