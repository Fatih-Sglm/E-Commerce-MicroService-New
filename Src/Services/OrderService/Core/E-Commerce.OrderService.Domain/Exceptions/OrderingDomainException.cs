using System.Runtime.Serialization;

namespace E_Commerce.OrderService.Domain.Exceptions
{
    public class OrderingDomainException : Exception
    {
        public OrderingDomainException()
        {
        }

        public OrderingDomainException(string? message) : base(message)
        {
        }

        public OrderingDomainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected OrderingDomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
