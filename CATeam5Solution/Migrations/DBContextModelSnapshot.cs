﻿// <auto-generated />
using System;
using CATeam5Solution.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CATeam5Solution.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CATeam5Solution.Models.ActCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductsId");

                    b.ToTable("ActCode");
                });

            modelBuilder.Entity("CATeam5Solution.Models.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UsersId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("CATeam5Solution.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CATeam5Solution.Models.Products", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CATeam5Solution.Models.ProductsShoppingCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ShoppingCartId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductsId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("ProductsShoppingCart");
                });

            modelBuilder.Entity("CATeam5Solution.Models.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("CATeam5Solution.Models.ShoppingCart", b =>
                {
                    b.Property<Guid>("ShoppingCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ShoppingCartId");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingCart");
                });

            modelBuilder.Entity("CATeam5Solution.Models.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OrderProducts", b =>
                {
                    b.Property<Guid>("OrdersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OrdersId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("CATeam5Solution.Models.ActCode", b =>
                {
                    b.HasOne("CATeam5Solution.Models.Order", null)
                        .WithMany("ActCodes")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CATeam5Solution.Models.Products", null)
                        .WithMany("ActCodes")
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CATeam5Solution.Models.CartItem", b =>
                {
                    b.HasOne("CATeam5Solution.Models.Products", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId");

                    b.HasOne("CATeam5Solution.Models.Users", "Users")
                        .WithMany("CartItems")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("CATeam5Solution.Models.Order", b =>
                {
                    b.HasOne("CATeam5Solution.Models.Users", null)
                        .WithMany("Order")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CATeam5Solution.Models.ProductsShoppingCart", b =>
                {
                    b.HasOne("CATeam5Solution.Models.Products", "Products")
                        .WithMany("ProductsShoppingCarts")
                        .HasForeignKey("ProductsId");

                    b.HasOne("CATeam5Solution.Models.ShoppingCart", "ShoppingCart")
                        .WithMany("ProductsShoppingCarts")
                        .HasForeignKey("ShoppingCartId");

                    b.Navigation("Products");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("CATeam5Solution.Models.Session", b =>
                {
                    b.HasOne("CATeam5Solution.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("CATeam5Solution.Models.ShoppingCart", b =>
                {
                    b.HasOne("CATeam5Solution.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OrderProducts", b =>
                {
                    b.HasOne("CATeam5Solution.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CATeam5Solution.Models.Products", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CATeam5Solution.Models.Order", b =>
                {
                    b.Navigation("ActCodes");
                });

            modelBuilder.Entity("CATeam5Solution.Models.Products", b =>
                {
                    b.Navigation("ActCodes");

                    b.Navigation("CartItems");

                    b.Navigation("ProductsShoppingCarts");
                });

            modelBuilder.Entity("CATeam5Solution.Models.ShoppingCart", b =>
                {
                    b.Navigation("ProductsShoppingCarts");
                });

            modelBuilder.Entity("CATeam5Solution.Models.Users", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}