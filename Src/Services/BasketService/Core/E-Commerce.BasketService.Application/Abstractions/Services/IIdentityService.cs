namespace E_Commerce.BasketService.Application.Abstractions.Services
{
    public interface IIdentityService
    {
        (string FullName, string Email) GetUserInfo();
        string GetUserName();
    }
}
