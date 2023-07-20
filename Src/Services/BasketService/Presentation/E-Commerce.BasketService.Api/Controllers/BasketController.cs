using E_Commerce.BasketService.Application.Abstractions.Services;
using E_Commerce.BasketService.Domain.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.BasketService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _service;
        private readonly IBus bus;

        public BasketController(IBasketService service, IBus bus)
        {
            _service = service;
            this.bus = bus;
        }

        [HttpGet("GetBasket")]
        public async Task<IActionResult> GetBasket()
        {
            return Ok(await _service.GetBasket());
        }


        [HttpGet("GetBasketLa")]
        public async Task<IActionResult> GetBasketLa()
        {
            var basket = new BasketItem()
            {
                Id = Guid.NewGuid(),
                OldUnitPrice = 0,
                PictureUrl = "nike.png",
                ProductId = 265,
                ProductName = "Nike",
                Quantity = 15,
                UnitPrice = 2
            };
            await bus.Publish(basket);
            return Ok("Ok");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CustomerBasket basket)
        {
            return Ok(await _service.UpdateBasketAsync(basket));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] BasketItem basketItem)
        {
            await _service.AddItemToBasket(basketItem);
            return Ok();
        }

        [HttpPost("CheckOut")]
        public async Task<IActionResult> CheckOut([FromBody] BasketCheckout basketCheckout)
        {
            await _service.CheckOutAsync(basketCheckout);
            return Accepted();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBasketAsync(string Id)
        {
            await _service.DeleteBasketByIdAsync(Id);
            return Ok();
        }

        [HttpDelete("DeleteBasketItem/{id}")]
        public async Task<IActionResult> DeleteBasketItemAsync(string id)
        {
            await _service.DeleteBasketItemAsync(id);
            return Ok("product was deleted");
        }
    }
}
