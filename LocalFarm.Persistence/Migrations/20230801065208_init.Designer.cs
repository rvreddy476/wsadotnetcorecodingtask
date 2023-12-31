﻿// <auto-generated />
using System;
using LocalFarm.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocalFarm.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230801065208_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LocalFarm.Domain.Common.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscountCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("LocalFarm.Domain.Common.DiscountDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiscountId")
                        .HasColumnType("int");

                    b.Property<int?>("DiscountTypeId")
                        .HasColumnType("int");

                    b.Property<double>("DiscountValue")
                        .HasColumnType("float");

                    b.Property<int>("DiscountedProductID")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsApplicableForEachProduct")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsUnLimited")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Limit")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("QuantityThreshold")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiscountId");

                    b.HasIndex("DiscountTypeId");

                    b.HasIndex("ProductId");

                    b.ToTable("DiscountDetails");
                });

            modelBuilder.Entity("LocalFarm.Domain.Common.DiscountType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DiscountsTypes");
                });

            modelBuilder.Entity("LocalFarm.Domain.Common.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("LocalFarm.Domain.Common.DiscountDetail", b =>
                {
                    b.HasOne("LocalFarm.Domain.Common.Discount", "Discount")
                        .WithMany("DiscountDetails")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocalFarm.Domain.Common.DiscountType", "DiscountType")
                        .WithMany()
                        .HasForeignKey("DiscountTypeId");

                    b.HasOne("LocalFarm.Domain.Common.Product", "Product")
                        .WithMany("DiscountDetails")
                        .HasForeignKey("ProductId");

                    b.Navigation("Discount");

                    b.Navigation("DiscountType");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("LocalFarm.Domain.Common.Discount", b =>
                {
                    b.Navigation("DiscountDetails");
                });

            modelBuilder.Entity("LocalFarm.Domain.Common.Product", b =>
                {
                    b.Navigation("DiscountDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
