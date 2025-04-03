﻿// <auto-generated />
using System;
using InventarioVeagroApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InventarioVeagroApi.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20250211173321_Customers")]
    partial class Customers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InventarioVeagroApi.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("direccion");

                    b.Property<string>("Cellphone")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("telefono");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("dni");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("correo");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.Property<string>("StatusRecord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("status_record");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("InventarioVeagroApi.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<decimal>("amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("auxiliaryCode")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("auxiliary_code");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("create_date");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mainCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("main_code");

                    b.Property<string>("measurementUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("measurement_unit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("recordStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("record_status");

                    b.Property<decimal>("stockAvailable")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("stock_available");

                    b.HasKey("id");

                    b.HasIndex("mainCode")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("InventarioVeagroApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ide");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("dni");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("RolName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("rol_name");

                    b.Property<bool>("StatusAccount")
                        .HasColumnType("bit")
                        .HasColumnName("status_account");

                    b.Property<string>("StatusRecord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("status_record");

                    b.HasKey("Id");

                    b.HasIndex("Dni")
                        .IsUnique();

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
