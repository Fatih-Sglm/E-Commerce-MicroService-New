using E_Commerce.OrderService.Domain.AggregateModels.OrderAggregate;
using E_Commerce.OrderService.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.OrderService.Persistence.EntitiyConfigurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order", OrderDbContext.DEFAULT_SCHEMA);

            builder.HasKey(o => o.Id);
            builder.Property(i => i.Id);
            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.CreateDate);
            builder.OwnsOne(o => o.Address, a =>
            {
                a.WithOwner();
            });

            builder.Property<int>("orderStatusId").UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("orderStatusId").IsRequired();

            var navigation = builder.Metadata.FindNavigation(nameof(Order.OrderItems));
            navigation!.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasOne(o => o.Buyer).WithMany().HasForeignKey(o => o.BuyerId).IsRequired(false);


            builder.HasOne(o => o.OrderStatus).WithMany().HasForeignKey("orderStatusId");
        }
    }
}
