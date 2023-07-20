using E_Commerce.OrderService.Domain.Exceptions;
using E_Commerce.OrderService.Domain.SeedWork;

namespace E_Commerce.OrderService.Domain.AggregateModels.OrderAggregate
{
    public class OrderStatus : Enumeration
    {
        public readonly static OrderStatus Submitted = new(1, nameof(Submitted).ToLowerInvariant());
        public readonly static OrderStatus AwaitingPayment = new(2, nameof(AwaitingPayment).ToLowerInvariant());
        public readonly static OrderStatus AwaitingValidation = new(3, nameof(AwaitingValidation).ToLowerInvariant());
        public readonly static OrderStatus StockConfirmed = new(4, nameof(StockConfirmed).ToLowerInvariant());
        public readonly static OrderStatus Paid = new(5, nameof(Paid).ToLowerInvariant());
        public readonly static OrderStatus Shipped = new(6, nameof(Shipped).ToLowerInvariant());
        public readonly static OrderStatus Cancelled = new(7, nameof(Cancelled).ToLowerInvariant());


        public OrderStatus(int id, string name) : base(id, name)
        {

        }
        public static IEnumerable<OrderStatus> List() =>
            new[] { Submitted, AwaitingPayment, AwaitingValidation, StockConfirmed, Paid, Shipped, Cancelled };

        public static OrderStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            return state ?? throw new OrderingDomainException($"Possible values for OrderStatus: {string.Join(",", List().Select(s => s.Name))}");
        }

        public static OrderStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            return state ?? throw new OrderingDomainException($"Possible values for OrderStatus: {string.Join(",", List().Select(s => s.Name))}");
        }
    }
}
