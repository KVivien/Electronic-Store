﻿// <auto-generated />
using System;
using Electronic_Store.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Electronic_Store.Migrations
{
    [DbContext(typeof(Electronic_StoreContext))]
    [Migration("20240113132229_Vendor")]
    partial class Vendor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Electronic_Store.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<DateTime>("PublishingDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(6,2)");

                    b.Property<int?>("VendorID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("VendorID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Electronic_Store.Models.Vendor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Vendor");
                });

            modelBuilder.Entity("Electronic_Store.Models.Product", b =>
                {
                    b.HasOne("Electronic_Store.Models.Vendor", "Vendor")
                        .WithMany("Products")
                        .HasForeignKey("VendorID");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("Electronic_Store.Models.Vendor", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}