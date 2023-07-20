using E_Commerce.OrderService.Domain.AggregateModels.OrderAggregate;
using E_Commerce.OrderService.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.OrderService.Persistence.EntitiyConfigurations
{
    internal class OrderStatusEntityConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.ToTable("orderstatus", OrderDbContext.DEFAULT_SCHEMA);

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();

            OrderStatus[] orderStatuses = new OrderStatus[]
            {
                new OrderStatus(1,"Submitted"),
                new OrderStatus(2 ,"AwaitingPayment"),
                new OrderStatus(3,"AwaitingValidation"),
                new OrderStatus(4,"StockConfirmed"),
                new OrderStatus(5,"Paid"),
                new OrderStatus(6,"Shipped"),
                new OrderStatus(7,"Cancelled"),
            };
            builder.HasData(orderStatuses);
        }
    }
}
