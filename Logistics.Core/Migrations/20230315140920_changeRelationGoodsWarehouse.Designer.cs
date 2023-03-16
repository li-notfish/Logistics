﻿// <auto-generated />
using System;
using Logistics.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Logistics.Core.Migrations
{
    [DbContext(typeof(LogisticsContext))]
    [Migration("20230315140920_changeRelationGoodsWarehouse")]
    partial class changeRelationGoodsWarehouse
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("Logistics.Shared.Model.Administrators", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("Logistics.Shared.Model.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("Logistics.Shared.Model.Goods", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<int?>("WarehouseId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.HasIndex("WarehouseId");

                    b.ToTable("Goodes");
                });

            modelBuilder.Entity("Logistics.Shared.Model.Order", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("varchar(64)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DeliveryId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GoodsId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderInfo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderState")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Recipient")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RecipientCity")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RecipientPhone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SenderCity")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SenderPhone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("OrderId");

                    b.HasIndex("DeliveryId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Logistics.Shared.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Logistics.Shared.Model.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("Logistics.Shared.Model.Goods", b =>
                {
                    b.HasOne("Logistics.Shared.Model.Order", "Order")
                        .WithOne("Goods")
                        .HasForeignKey("Logistics.Shared.Model.Goods", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Logistics.Shared.Model.Warehouse", "Warehouse")
                        .WithMany("Goods")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Logistics.Shared.Model.Order", b =>
                {
                    b.HasOne("Logistics.Shared.Model.Delivery", "Delivery")
                        .WithMany("Orders")
                        .HasForeignKey("DeliveryId");

                    b.Navigation("Delivery");
                });

            modelBuilder.Entity("Logistics.Shared.Model.Delivery", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Logistics.Shared.Model.Order", b =>
                {
                    b.Navigation("Goods");
                });

            modelBuilder.Entity("Logistics.Shared.Model.Warehouse", b =>
                {
                    b.Navigation("Goods");
                });
#pragma warning restore 612, 618
        }
    }
}