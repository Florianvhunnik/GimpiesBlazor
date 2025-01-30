﻿// <auto-generated />
using System;
using GimpiesBlazor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GimpiesBlazor.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GimpiesBlazor.Models.Entities.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FkRoleId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AccountId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("FkRoleId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("GimpiesBlazor.Models.Entities.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("GimpiesBlazor.Models.Entities.Color", b =>
                {
                    b.Property<int>("ColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColorId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ColorId");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("GimpiesBlazor.Models.Entities.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PermissionId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PermissionId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("GimpiesBlazor.Models.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("GimpiesBlazor.Models.Entities.RolePermission", b =>
                {
                    b.Property<int>("FkRoleId")
                        .HasColumnType("int");

                    b.Property<int>("FkPermissionId")
                        .HasColumnType("int");

                    b.HasKey("FkRoleId", "FkPermissionId");

                    b.HasIndex("FkPermissionId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("GimpiesBlazor.Models.Entities.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleId"));

                    b.Property<int>("FkAccountId")
                        .HasColumnType("int");

                    b.Property<int>("FkStockId")
                        .HasColumnType("int");

                    b.Property<int>("NumberSold")
                        .HasColumnType("int");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalSalePrice")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("SaleId");

                    b.HasIndex("FkAccountId");

                    b.HasIndex("FkStockId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("GimpiesBlazor.Models.Entities.Stock", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StockId"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("FkBrandId")
                        .HasColumnType("int");

                    b.Property<int>("FkColorId")
                        .HasColumnType("int");

                    b.Property<string>("FkTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("StockId");

                    b.HasIndex("FkBrandId");

                    b.HasIndex("FkColorId");

                    b.HasIndex("TypeId");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("GimpiesBlazor.Models.Entities.StockType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TypeId");

                    b.ToTable("StockTypes");
                });

            modelBuilder.Entity("GimpiesBlazor.Models.Entities.Account", b =>
                {
                    b.HasOne("GimpiesBlazor.Models.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("FkRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("GimpiesBlazor.Models.Entities.RolePermission", b =>
                {
                    b.HasOne("GimpiesBlazor.Models.Entities.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("FkPermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GimpiesBlazor.Models.Entities.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("FkRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("GimpiesBlazor.Models.Entities.Sale", b =>
                {
                    b.HasOne("GimpiesBlazor.Models.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("FkAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GimpiesBlazor.Models.Entities.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("FkStockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("GimpiesBlazor.Models.Entities.Stock", b =>
                {
                    b.HasOne("GimpiesBlazor.Models.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("FkBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GimpiesBlazor.Models.Entities.Color", "Color")
                        .WithMany()
                        .HasForeignKey("FkColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GimpiesBlazor.Models.Entities.StockType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Color");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("GimpiesBlazor.Models.Entities.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("GimpiesBlazor.Models.Entities.Role", b =>
                {
                    b.Navigation("RolePermissions");
                });
#pragma warning restore 612, 618
        }
    }
}
