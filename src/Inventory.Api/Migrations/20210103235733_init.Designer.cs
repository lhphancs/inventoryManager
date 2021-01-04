﻿// <auto-generated />
using System;
using Inventory.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inventory.Api.Migrations
{
    [DbContext(typeof(InventoryContext))]
    [Migration("20210103235733_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Inventory.Api.Aggregates.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ModifiedDateTime")
                        .HasColumnType("datetime");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("ShelfProductId")
                        .HasColumnType("int");

                    b.Property<int?>("WholesalerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WholesalerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Inventory.Api.Aggregates.Shelf.Shelf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ModifiedDateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Shelfs");
                });

            modelBuilder.Entity("Inventory.Api.Aggregates.Wholesaler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ModifiedDateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Wholesalers");
                });

            modelBuilder.Entity("Inventory.Api.Infrastructure.EntityConfigurations.ManyToManyClasses.ProductWholesaler", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("WholesalerId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "WholesalerId");

                    b.HasIndex("WholesalerId");

                    b.ToTable("ProductWholesaler");
                });

            modelBuilder.Entity("Inventory.Api.Aggregates.Product", b =>
                {
                    b.HasOne("Inventory.Api.Aggregates.Wholesaler", null)
                        .WithMany("Products")
                        .HasForeignKey("WholesalerId");

                    b.OwnsOne("Inventory.Api.Aggregates.Shelf.ShelfProduct", "ShelfProduct", b1 =>
                        {
                            b1.Property<int>("ProductId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<int>("Column")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .HasColumnType("int");

                            b1.Property<int>("Row")
                                .HasColumnType("int");

                            b1.Property<int>("ShelfId")
                                .HasColumnType("int");

                            b1.HasKey("ProductId");

                            b1.HasIndex("ShelfId");

                            b1.ToTable("Products");

                            b1.WithOwner("Product")
                                .HasForeignKey("ProductId");

                            b1.HasOne("Inventory.Api.Aggregates.Shelf.Shelf", "Shelf")
                                .WithMany()
                                .HasForeignKey("ShelfId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();
                        });

                    b.OwnsOne("Inventory.Api.ValueObjects.ProductInfo", "ProductInfo", b1 =>
                        {
                            b1.Property<int>("ProductId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<string>("Brand")
                                .HasColumnType("text");

                            b1.Property<string>("Description")
                                .HasColumnType("text");

                            b1.Property<string>("ExpirationLocation")
                                .HasColumnType("text");

                            b1.Property<string>("Name")
                                .HasColumnType("text");

                            b1.Property<int>("OunceWeight")
                                .HasColumnType("int");

                            b1.Property<bool>("RequiresBox")
                                .HasColumnType("bit");

                            b1.Property<bool>("RequiresBubbleWrap")
                                .HasColumnType("bit");

                            b1.Property<bool>("RequiresPadding")
                                .HasColumnType("bit");

                            b1.Property<string>("Upc")
                                .HasColumnType("varchar(767)");

                            b1.HasKey("ProductId");

                            b1.HasIndex("Upc")
                                .IsUnique();

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });
                });

            modelBuilder.Entity("Inventory.Api.Aggregates.Shelf.Shelf", b =>
                {
                    b.OwnsMany("Inventory.Api.Aggregates.Shelf.ShelfProduct", "ShelfProducts", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<int>("Column")
                                .HasColumnType("int");

                            b1.Property<int>("ProductId")
                                .HasColumnType("int");

                            b1.Property<int>("Row")
                                .HasColumnType("int");

                            b1.Property<int>("ShelfId")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("ProductId")
                                .IsUnique();

                            b1.HasIndex("ShelfId");

                            b1.ToTable("Shelfs_ShelfProducts");

                            b1.HasOne("Inventory.Api.Aggregates.Product", "Product")
                                .WithMany()
                                .HasForeignKey("ProductId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner("Shelf")
                                .HasForeignKey("ShelfId");
                        });

                    b.OwnsOne("Inventory.Api.ValueObjects.ShelfInfo", "ShelfInfo", b1 =>
                        {
                            b1.Property<int>("ShelfId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<string>("Description")
                                .HasColumnType("text");

                            b1.Property<string>("Name")
                                .HasColumnType("varchar(767)");

                            b1.HasKey("ShelfId");

                            b1.HasIndex("Name")
                                .IsUnique();

                            b1.ToTable("Shelfs");

                            b1.WithOwner()
                                .HasForeignKey("ShelfId");
                        });
                });

            modelBuilder.Entity("Inventory.Api.Aggregates.Wholesaler", b =>
                {
                    b.OwnsOne("Inventory.Api.ValueObjects.WholesalerInfo", "WholesalerInfo", b1 =>
                        {
                            b1.Property<int>("WholesalerId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .HasColumnType("varchar(767)");

                            b1.HasKey("WholesalerId");

                            b1.HasIndex("Name")
                                .IsUnique();

                            b1.ToTable("Wholesalers");

                            b1.WithOwner()
                                .HasForeignKey("WholesalerId");

                            b1.OwnsOne("Inventory.Api.ValueObjects.Address", "Address", b2 =>
                                {
                                    b2.Property<int>("WholesalerInfoWholesalerId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int");

                                    b2.Property<string>("City")
                                        .HasColumnType("text");

                                    b2.Property<string>("Street")
                                        .HasColumnType("text");

                                    b2.Property<string>("ZipCode")
                                        .HasColumnType("text");

                                    b2.HasKey("WholesalerInfoWholesalerId");

                                    b2.ToTable("Wholesalers");

                                    b2.WithOwner()
                                        .HasForeignKey("WholesalerInfoWholesalerId");
                                });
                        });
                });

            modelBuilder.Entity("Inventory.Api.Infrastructure.EntityConfigurations.ManyToManyClasses.ProductWholesaler", b =>
                {
                    b.HasOne("Inventory.Api.Aggregates.Product", "Product")
                        .WithMany("ProductWholesalers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inventory.Api.Aggregates.Wholesaler", "Wholesaler")
                        .WithMany("ProductWholesalers")
                        .HasForeignKey("WholesalerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}