using E_Commerce.BasketService.Application.Abstractions.Repository;
using E_Commerce.BasketService.Application.Abstractions.Services;
using E_Commerce.BasketService.Application.IntegrationEvents.Events;
using E_Commerce.BasketService.Domain.Models;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace E_Commerce.BasketService.Persistence.Concrete.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IIdentityService _identityService;
        private readonly IBus busControl;
        private readonly ILogger<BasketService> _logger;

        public BasketService(IBasketRepository basketRepository, IIdentityService identityService, ILogger<BasketService> logger, IBus busControl)
        {
            _basketRepository = basketRepository;
            _identityService = identityService;
            _logger = logger;
            this.busControl = busControl;
        }

        public async Task AddItemToBasket(BasketItem basketItem)
        {

            var userName = /*await _identityService.GetUserName()*/ "Fatih";
            var basket = await _basketRepository.GetBasketAsync(userName);
            basket ??= new CustomerBasket(userName);
            basket.Items.Add(basketItem);
            await _basketRepository.UpdateBasketAsync(basket);
        }

        public async Task CheckOutAsync(BasketCheckout basketCheckout)
        {
            var userName = _identityService.GetUserName();
            (string FullName, string Email) = _identityService.GetUserInfo();
            var basket = await _basketRepository.GetBasketAsync(userName);

            if (basket is null)
            {
                return;
            }

            var eventMessage = new OrderCreatedIntegrationEvent
                (userName, FullName, Email, basketCheckout.City, basketCheckout.Street,
            basketCheckout.Street, basketCheckout.Country, basketCheckout.ZipCode, basketCheckout.Alias,
            basketCheckout.CardNumber, basketCheckout.CardHolderName,
            basketCheckout.ExpirationMonth, basketCheckout.ExpirationYear, basketCheckout.CardSecurityNumber, basketCheckout.CardTypeId,
            basket, basketCheckout.WillPaymentRecorded);

            try
            {
                await busControl.Publish(eventMessage);
            }
            catch (Exception)
            {
                _logger.LogError("Mesaj Publish edilirken bir hata oluştu");

                return;
            }
        }

        public async Task DeleteBasketByIdAsync(string id)
        {
            var username = _identityService.GetUserName();
            await _basketRepository.DeleteBasketItemAsync(username, id);
        }

        public async Task DeleteBasketItemAsync(string id)
        {
            var username = _identityService.GetUserName();
            await _basketRepository.DeleteBasketItemAsync(username, id);
        }

        public async Task<CustomerBasket> GetBasket()
        {
            var userName = _identityService.GetUserName();
            var basket = await _basketRepository.GetBasketAsync(userName);
            return basket ?? new CustomerBasket(userName);
        }

        public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket customerBasket)
        {
            return await _basketRepository.UpdateBasketAsync(customerBasket);
        }
    }
}
