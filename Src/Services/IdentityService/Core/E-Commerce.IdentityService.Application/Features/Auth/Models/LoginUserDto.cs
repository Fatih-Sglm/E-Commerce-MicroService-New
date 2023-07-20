namespace E_Commerce.IdentityService.Application.Features.Auth.Models
{
    public class LoginUserDto
    {
        public required string UserNameOrEmail { get; set; }
        public required string Password { get; set; }
    }
}
