﻿// <auto-generated />
using System;
using CarDealership.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Repositories.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210930184117_SeedCarsSellers")]
    partial class SeedCarsSellers
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

                    b.HasKey("Id");

                    b.HasIndex("CarId");

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

                    b.Property<DateTime>("ProductionYear")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Seats")
                        .HasColumnType("integer");

                    b.Property<int>("TransmissionType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7b7e48ef-c542-4d30-8de6-73624c0d76df"),
                            Brand = "BMW",
                            Doors = 5,
                            EngineVolume = 1999,
                            Kilometers = 100000,
                            Model = "520",
                            Power = 150,
                            ProductionYear = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Seats = 5,
                            TransmissionType = 1
                        },
                        new
                        {
                            Id = new Guid("233fa880-bd3b-440c-b0da-f9afb7fe6292"),
                            Brand = "Audi",
                            Doors = 5,
                            EngineVolume = 1800,
                            Kilometers = 90000,
                            Model = "Q3",
                            Power = 170,
                            ProductionYear = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Seats = 5,
                            TransmissionType = 0
                        });
                });

            modelBuilder.Entity("CarDealership.Model.Entities.Discount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Discount");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fcf32728-8e0e-429b-9c18-7e707c52f7a3"),
                            Description = "New customer",
                            Value = 100
                        },
                        new
                        {
                            Id = new Guid("5dbbb375-f3fd-430f-8d9f-bfa46a64d852"),
                            Description = "Returning customer",
                            Value = 5
                        },
                        new
                        {
                            Id = new Guid("47bd7d45-b684-4bc3-b98a-08b436407f81"),
                            Description = "Black Friday",
                            Value = 10
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
                            Id = new Guid("51c59ac5-80ed-4a9d-af62-78a4d4aca32c"),
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

                    b.Navigation("Car");
                });
#pragma warning restore 612, 618
        }
    }
}