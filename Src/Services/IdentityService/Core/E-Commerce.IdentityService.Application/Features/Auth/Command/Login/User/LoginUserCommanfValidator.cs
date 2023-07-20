using FluentValidation;

namespace E_Commerce.IdentityService.Application.Features.Auth.Command.Login.User
{
    public class LoginUserCommanfValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommanfValidator()
        {
            RuleFor(i => i.UserNameOrEmail).NotNull().NotEmpty().WithMessage("Kullanıcı Adı veya Email Kısmı Boş Geçilemez");
            RuleFor(i => i.Password).NotNull().NotEmpty().WithMessage("Şifre Kısmı Boş Geçilemez");
        }
    }
}
