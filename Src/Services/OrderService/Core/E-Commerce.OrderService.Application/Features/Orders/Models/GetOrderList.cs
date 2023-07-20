namespace E_Commerce.OrderService.Application.Features.Orders.Models
{
    public class GetOrderList : GetUserOrderList
    {
        public required string BuyerName { get; init; }
    }
}
