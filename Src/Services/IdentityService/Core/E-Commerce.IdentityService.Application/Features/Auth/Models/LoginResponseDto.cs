namespace E_Commerce.IdentityService.Application.Features.Auth.Models
{
    public class LoginResponseDto
    {
        public required string Token { get; set; }
        public required string RefreshToken { get; set; }
    }
}
