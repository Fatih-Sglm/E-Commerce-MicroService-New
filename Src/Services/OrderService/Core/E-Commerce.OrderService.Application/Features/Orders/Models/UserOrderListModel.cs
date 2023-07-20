using E_Commerce.OrderService.Application.Models.Paging;

namespace E_Commerce.OrderService.Application.Features.Orders.Models
{
    public class UserOrderListModel : BasePageableModel
    {
        public List<GetUserOrderList> Items { get; set; } = new List<GetUserOrderList>();
    }
}
