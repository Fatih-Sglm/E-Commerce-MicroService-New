using E_Commerce.OrderService.Application.Models.Paging;

namespace E_Commerce.OrderService.Application.Features.Orders.Models
{
    public class AllOrdersListModel : BasePageableModel
    {
        public List<GetOrderList> Items { get; set; } = new List<GetOrderList>();
    }
}
