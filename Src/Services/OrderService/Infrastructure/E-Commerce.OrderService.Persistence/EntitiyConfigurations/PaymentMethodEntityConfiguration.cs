using E_Commerce.OrderService.Domain.AggregateModels.BuyerAggregate;
using E_Commerce.OrderService.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.OrderService.Persistence.EntitiyConfigurations
{
    internal class PaymentMethodEntityConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> paymentConfiguration)
        {
            paymentConfiguration.ToTable("PaymentMethods", OrderDbContext.DEFAULT_SCHEMA);

            paymentConfiguration.Ignore(b => b.DomainEvents);

            paymentConfiguration.HasKey(o => o.Id);
            paymentConfiguration.Property(i => i.Id).HasColumnName("Id");

            //paymentConfiguration.Property<Guid>("BuyerId")
            //    .IsRequired();

            paymentConfiguration
                .Property(i => i.CardHolderName)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CardHolderName")
                .HasMaxLength(200)
                .IsRequired();

            paymentConfiguration
                .Property(i => i.Alias)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Alias")
                .HasMaxLength(200)
                .IsRequired();

            paymentConfiguration
                .Property(i => i.CardNumber)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CardNumber")
                .HasMaxLength(25)
                .IsRequired();

            paymentConfiguration
                .Property(i => i.ExpirationMonth)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ExpirationMonth")
                .HasMaxLength(25)
                .IsRequired();

            paymentConfiguration
                .Property(i => i.ExpirationYear)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ExpirationYear")
                .HasMaxLength(25)
                .IsRequired();

            paymentConfiguration
                .Property(i => i.CardType.Id)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CardTypeId")
                .IsRequired();

            paymentConfiguration.HasOne(p => p.CardType)
                .WithMany()
                .HasForeignKey(i => i.CardType.Id);
        }
    }
}
