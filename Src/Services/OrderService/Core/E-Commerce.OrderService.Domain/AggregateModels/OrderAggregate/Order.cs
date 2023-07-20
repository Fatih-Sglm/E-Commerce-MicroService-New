using E_Commerce.OrderService.Domain.AggregateModels.BuyerAggregate;
using E_Commerce.OrderService.Domain.Events;
using E_Commerce.OrderService.Domain.Models;
using E_Commerce.OrderService.Domain.SeedWork;

namespace E_Commerce.OrderService.Domain.AggregateModels.OrderAggregate
{
    public class Order : BaseEntity, IAggregateRoot
    {
        public string OrderNumber { get; set; }
        public Guid? BuyerId { get; private set; }
        public Buyer? Buyer { get; private set; }
        public Address Address { get; private set; }
        public OrderStatus OrderStatus { get; set; }
        private readonly List<OrderItem> _orderItems = new();
        public IEnumerable<OrderItem> OrderItems => _orderItems.AsReadOnly();
        public Guid? PaymentMethodId { get; private set; }
        public double OrderAmount { get; private set; }
        public DateTime OrderDate { get => base.CreateDate; set => base.CreateDate = value; }


        public Order(string userName, string fullName, string mail, Address address, string? alias, CreditCard creditCard, int cardTypeId, OrderStatus orderStatus, double orderAmount, bool willPaymentRecord)
        {
            OrderStatus = orderStatus;
            Address = address;
            OrderAmount = orderAmount;
            OrderNumber = string.Concat(userName[..3], Guid.NewGuid().ToString("d"));
            AddOrderStartedDomainEvent(userName, fullName, mail, cardTypeId, alias, creditCard, willPaymentRecord);
        }


        private void AddOrderStartedDomainEvent(string userName, string fullName, string email, int cardTypeId, string? alias, CreditCard creditCard, bool willPaymentRecord)
        {
            var orderStartedDomainEvent = new OrderStartedDomainEvent(this, userName, fullName, email, cardTypeId, alias!, creditCard, willPaymentRecord);

            AddDomainEvent(orderStartedDomainEvent);
        }

        public void AddOrderItem(uint productId, string productName, decimal unitPrice, string pictureUrl, uint quantity = 1)
        {
            // orderItem validations

            var orderItem = new OrderItem(productId, productName, unitPrice, pictureUrl, quantity);
            _orderItems.Add(orderItem);
        }

        public void SetBuyerId(Guid buyerId)
        {
            BuyerId = buyerId;
        }

        public void SetOrderStatus(OrderStatus orderStatus)
        {
            OrderStatus = orderStatus;
        }

        public void SetPaymentMethodId(Guid? paymentMethodId)
        {
            PaymentMethodId = paymentMethodId;
        }
    }
}
