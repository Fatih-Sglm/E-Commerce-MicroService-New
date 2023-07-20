using E_Commerce.BasketService.Domain.Models;

namespace E_Commerce.BasketService.Application.Abstractions.Services
{
    public interface IBasketService
    {
        Task AddItemToBasket(BasketItem basketItem);
        Task<CustomerBasket> GetBasket();
        Task CheckOutAsync(BasketCheckout basketCheckout);
        Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket customerBasket);
        Task DeleteBasketByIdAsync(string userName);

        Task DeleteBasketItemAsync(string id);
    }
}
