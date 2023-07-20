using E_Commerce.BasketService.Domain.Models;

namespace E_Commerce.BasketService.Application.Abstractions.Repository
{
    public interface IBasketRepository
    {
        Task<CustomerBasket?> GetBasketAsync(string buyerUserName);
        //IEnumerable<string> GetUsers();
        Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket customerBasket);
        Task DeleteBasketAsync(string id);

        Task DeleteBasketItemAsync(string buyerUserName, string id);
    }
}
