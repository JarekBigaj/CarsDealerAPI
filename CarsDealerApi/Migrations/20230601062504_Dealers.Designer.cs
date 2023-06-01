﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarsDealerApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230601062504_Dealers")]
    partial class Dealers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarsDealerApi.Model.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DealerId")
                        .HasColumnType("int");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mileage")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DealerId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarsDealerApi.Model.DealerAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Dealers");
                });

            modelBuilder.Entity("CarsDealerApi.Model.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<decimal>("ProposedAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("CarsDealerApi.Model.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("Payment")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("CarsDealerApi.Model.TestDrive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("TestDrives");
                });

            modelBuilder.Entity("CarsDealerApi.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarsDealerApi.Model.Car", b =>
                {
                    b.HasOne("CarsDealerApi.Model.DealerAccount", "Dealer")
                        .WithMany("Cars")
                        .HasForeignKey("DealerId");

                    b.Navigation("Dealer");
                });

            modelBuilder.Entity("CarsDealerApi.Model.Offer", b =>
                {
                    b.HasOne("CarsDealerApi.Model.Car", "Car")
                        .WithMany("Offers")
                        .HasForeignKey("CarId");

                    b.HasOne("CarsDealerApi.Model.User", "User")
                        .WithMany("Offers")
                        .HasForeignKey("UserId");

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarsDealerApi.Model.Purchase", b =>
                {
                    b.HasOne("CarsDealerApi.Model.Car", "Car")
                        .WithMany("Purchases")
                        .HasForeignKey("CarId");

                    b.HasOne("CarsDealerApi.Model.User", "User")
                        .WithMany("Purchases")
                        .HasForeignKey("UserId");

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarsDealerApi.Model.TestDrive", b =>
                {
                    b.HasOne("CarsDealerApi.Model.Car", "Car")
                        .WithMany("TestDrive")
                        .HasForeignKey("CarId");

                    b.HasOne("CarsDealerApi.Model.User", "User")
                        .WithMany("TestDrives")
                        .HasForeignKey("UserId");

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarsDealerApi.Model.Car", b =>
                {
                    b.Navigation("Offers");

                    b.Navigation("Purchases");

                    b.Navigation("TestDrive");
                });

            modelBuilder.Entity("CarsDealerApi.Model.DealerAccount", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarsDealerApi.Model.User", b =>
                {
                    b.Navigation("Offers");

                    b.Navigation("Purchases");

                    b.Navigation("TestDrives");
                });
#pragma warning restore 612, 618
        }
    }
}
