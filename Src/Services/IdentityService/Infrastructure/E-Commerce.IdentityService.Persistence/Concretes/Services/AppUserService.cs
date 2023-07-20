using AutoMapper;
using E_Commerce.IdentityService.Application.Abstractions.Services;
using E_Commerce.IdentityService.Application.Exceptions;
using E_Commerce.IdentityService.Application.Features.AppUsers.Command.CreateUser;
using E_Commerce.IdentityService.Application.Features.AppUsers.Command.ResetPassword;
using E_Commerce.IdentityService.Application.Features.AppUsers.Command.UpdateUserPassword;
using E_Commerce.IdentityService.Application.Features.Auth.Rules;
using E_Commerce.IdentityService.Application.IntegrationEvents;
using E_Commerce.IdentityService.Domain.Entities.Identity;
using MassTransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Json;

namespace E_Commerce.IdentityService.Persistence.Concretes.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IVeriyService _verifyService;
        private readonly IBus _eventBus;

        public AppUserService(UserManager<AppUser> userManager, IMapper mapper, IVeriyService verifyService, IBus eventBus)
        {
            _userManager = userManager;
            _mapper = mapper;
            _verifyService = verifyService;
            _eventBus = eventBus;
        }

        public async Task CreateUser(CreateUserCommand request)
        {
            AppUser appUser = _mapper.Map<AppUser>(request);
            IdentityResult result = await _userManager.CreateAsync(appUser, request.Password);
            if (!result.Succeeded) { throw new IdentityException(JsonSerializer.Serialize(result.Errors)); }
            await CreateConfirmUserEmailMessageAsync(appUser);
        }

        public async Task ResetPassword(ResetPasswordCommand command)
        {
            AppUser? appUser = await _userManager.FindByEmailAsync(command.Email);
            await appUser.CheckUserIsNull();
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(appUser!);
            UserNotificationIntegrationEvent @event = new()
            {
                UrlRoute = "reset-password",
                Email = appUser!.Email!,
                FullName = $"{appUser.FirstName} {appUser.LastName}",
                UserId = appUser.Id.ToString(),
                Token = resetToken,
                MessageType = MessageType.ResetPassword
            };

            await _eventBus.Publish(@event);
        }

        public async Task UpdatePassword(UpdateUserPasswordResetCommand command)
        {
            if (!command.Password.Equals(command.ConfirmPassword))
                throw new IdentityException("");

            AppUser? appUser = await _userManager.FindByIdAsync(command.UserId);
            await appUser.CheckUserIsNull();
            var result = await _verifyService.VerifyResetPassword(new() { Token = command.ResetToken, UserId = command.UserId });

            IdentityResult identityResult = await _userManager.ResetPasswordAsync(appUser!, result, command.Password);
            if (!identityResult.Succeeded)
                throw new IdentityException("");
            await _userManager.UpdateSecurityStampAsync(appUser!);
        }

        private async Task CreateConfirmUserEmailMessageAsync(AppUser appUser)
        {
            await appUser!.CheckUserIsNull();
            string resetToken = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            byte[] tokenBytes = Encoding.UTF8.GetBytes(resetToken);
            resetToken = WebEncoders.Base64UrlEncode(tokenBytes);

            UserNotificationIntegrationEvent @event = new()
            {
                UrlRoute = "Confirm-Email",
                Email = appUser.Email!,
                FullName = $"{appUser.FirstName} {appUser.LastName}",
                UserId = appUser.Id.ToString(),
                Token = resetToken,
                MessageType = MessageType.VerifyEmail
            };

            await _eventBus.Publish(@event);
        }
    }
}
