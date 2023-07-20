﻿// <auto-generated />
using System;
using E_Commerce.OrderService.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce.OrderService.Persistence.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    [Migration("20221201132317_Mig2")]
    partial class Mig2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_Commerce.OrderService.Domain.AggregaedModels.BuyerAggregate.Buyer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("buyers", "ordering");
                });

            modelBuilder.Entity("E_Commerce.OrderService.Domain.AggregaedModels.BuyerAggregate.CardType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("cardtypes", "ordering");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Amex"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Visa"
                        },
                        new
                        {
                            Id = 3,
                            Name = "MasterCard"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Capital One"
                        });
                });

            modelBuilder.Entity("E_Commerce.OrderService.Domain.AggregaedModels.BuyerAggregate.PaymentMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Alias");

                    b.Property<string>("CardHolderName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("CardHolderName");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("CardNumber");

                    b.Property<int>("CardTypeId")
                        .HasColumnType("int")
                        .HasColumnName("CardTypeId");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExpirationMonth")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("ExpirationMonth");

                    b.Property<string>("ExpirationYear")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("ExpirationYear");

                    b.Property<string>("SecurityNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CardTypeId");

                    b.ToTable("paymentmethods", "ordering");
                });

            modelBuilder.Entity("E_Commerce.OrderService.Domain.AggregaedModels.OrderAggregate.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BuyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OrderAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PaymentMethodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("orderStatusId")
                        .HasColumnType("int")
                        .HasColumnName("orderStatusId");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("orderStatusId");

                    b.ToTable("order", "ordering");
                });

            modelBuilder.Entity("E_Commerce.OrderService.Domain.AggregaedModels.OrderAggregate.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("orderItems", "ordering");
                });

            modelBuilder.Entity("E_Commerce.OrderService.Domain.AggregaedModels.OrderAggregate.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("orderstatus", "ordering");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Submitted"
                        },
                        new
                        {
                            Id = 2,
                            Name = "AwaitingPayment"
                        },
                        new
                        {
                            Id = 3,
                            Name = "AwaitingValidation"
                        },
                        new
                        {
                            Id = 4,
                            Name = "StockConfirmed"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Paid"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Shipped"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Cancelled"
                        });
                });

            modelBuilder.Entity("E_Commerce.OrderService.Domain.AggregaedModels.BuyerAggregate.PaymentMethod", b =>
                {
                    b.HasOne("E_Commerce.OrderService.Domain.AggregaedModels.BuyerAggregate.CardType", "CardType")
                        .WithMany()
                        .HasForeignKey("CardTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce.OrderService.Domain.AggregaedModels.BuyerAggregate.Buyer", null)
                        .WithMany("PaymentMethods")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CardType");
                });

            modelBuilder.Entity("E_Commerce.OrderService.Domain.AggregaedModels.OrderAggregate.Order", b =>
                {
                    b.HasOne("E_Commerce.OrderService.Domain.AggregaedModels.BuyerAggregate.Buyer", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId");

                    b.HasOne("E_Commerce.OrderService.Domain.AggregaedModels.OrderAggregate.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("orderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("E_Commerce.OrderService.Domain.AggregaedModels.OrderAggregate.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("State")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderId");

                            b1.ToTable("order", "ordering");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("OrderStatus");
                });

            modelBuilder.Entity("E_Commerce.OrderService.Domain.AggregaedModels.OrderAggregate.OrderItem", b =>
                {
                    b.HasOne("E_Commerce.OrderService.Domain.AggregaedModels.OrderAggregate.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_Commerce.OrderService.Domain.AggregaedModels.BuyerAggregate.Buyer", b =>
                {
                    b.Navigation("PaymentMethods");
                });

            modelBuilder.Entity("E_Commerce.OrderService.Domain.AggregaedModels.OrderAggregate.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
