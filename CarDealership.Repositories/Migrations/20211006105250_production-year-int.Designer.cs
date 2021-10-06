﻿// <auto-generated />
using System;
using CarDealership.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CarDealership.Repositories.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20211006105250_production-year-int")]
    partial class productionyearint
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CarDealership.Model.Entities.Ad", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CarId")
                        .HasColumnType("uuid");

                    b.Property<int>("Currency")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<Guid?>("SellerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("SellerId");

                    b.ToTable("Ad");
                });

            modelBuilder.Entity("CarDealership.Model.Entities.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Brand")
                        .HasColumnType("text");

                    b.Property<int>("Doors")
                        .HasColumnType("integer");

                    b.Property<int>("EngineVolume")
                        .HasColumnType("integer");

                    b.Property<int>("Kilometers")
                        .HasColumnType("integer");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<int>("Power")
                        .HasColumnType("integer");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("integer");

                    b.Property<int>("Seats")
                        .HasColumnType("integer");

                    b.Property<int>("TransmissionType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c5d040f0-aa56-4923-8c03-82689650554d"),
                            Brand = "BMW",
                            Doors = 5,
                            EngineVolume = 1999,
                            Kilometers = 100000,
                            Model = "520",
                            Power = 150,
                            ProductionYear = 2000,
                            Seats = 5,
                            TransmissionType = 2
                        },
                        new
                        {
                            Id = new Guid("2523e318-f9fc-4beb-9347-e1ab0ae14347"),
                            Brand = "Audi",
                            Doors = 5,
                            EngineVolume = 1800,
                            Kilometers = 90000,
                            Model = "Q3",
                            Power = 170,
                            ProductionYear = 2010,
                            Seats = 5,
                            TransmissionType = 1
                        });
                });

            modelBuilder.Entity("CarDealership.Model.Entities.Discount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("PromoCode")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Discount");

                    b.HasData(
                        new
                        {
                            Id = new Guid("70511618-91ac-451f-8c45-5b52d2da9f86"),
                            PromoCode = "NEW",
                            Type = 1,
                            Value = 100
                        },
                        new
                        {
                            Id = new Guid("e7902086-8de5-4581-816c-d2c301448f10"),
                            PromoCode = "RETURN",
                            Type = 2,
                            Value = 5
                        },
                        new
                        {
                            Id = new Guid("bb6ff972-0c1f-4f12-b089-a12a301f7dea"),
                            PromoCode = "BF2021",
                            Type = 3,
                            Value = 10
                        },
                        new
                        {
                            Id = new Guid("0f68dad7-1809-477e-82b6-145dd7d98904"),
                            PromoCode = "No Discount",
                            Type = 0,
                            Value = 1
                        });
                });

            modelBuilder.Entity("CarDealership.Model.Entities.Seller", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Seller");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b1846008-e76a-4f59-aa64-cd247896a63e"),
                            Email = "john.smith@js.com",
                            Name = "John",
                            Surname = "Smith"
                        });
                });

            modelBuilder.Entity("CarDealership.Model.Entities.Ad", b =>
                {
                    b.HasOne("CarDealership.Model.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");

                    b.HasOne("CarDealership.Model.Entities.Seller", "Seller")
                        .WithMany("Ads")
                        .HasForeignKey("SellerId");

                    b.Navigation("Car");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("CarDealership.Model.Entities.Seller", b =>
                {
                    b.Navigation("Ads");
                });
#pragma warning restore 612, 618
        }
    }
}