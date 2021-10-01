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
    [Migration("20210930220133_SeedAds")]
    partial class SeedAds
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

                    b.Property<Guid>("CarId")
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("37513c6c-582a-4680-8932-dc13414d7cdc"),
                            CarId = new Guid("a312f304-cb73-4237-8773-0c367941e2c6"),
                            Currency = 1,
                            Description = "Lorem ipsum",
                            Price = 20000
                        });
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
                            Id = new Guid("a312f304-cb73-4237-8773-0c367941e2c6"),
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
                            Id = new Guid("90d80355-6ad9-454b-aab5-75d760089adc"),
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

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Discount");

                    b.HasData(
                        new
                        {
                            Id = new Guid("14f4ecff-6305-4a86-b123-3de5c8507ce5"),
                            Description = "New customer",
                            Type = 1,
                            Value = 100
                        },
                        new
                        {
                            Id = new Guid("05d5776c-3f21-473b-a27b-230b3ecb4b7b"),
                            Description = "Returning customer",
                            Type = 2,
                            Value = 5
                        },
                        new
                        {
                            Id = new Guid("726bf8e3-35aa-49ca-8db0-f775c5a7597c"),
                            Description = "Black Friday",
                            Type = 3,
                            Value = 10
                        },
                        new
                        {
                            Id = new Guid("bf6b3555-5ec8-4b9d-a071-52fbc55c7d32"),
                            Description = "No Discount",
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
                            Id = new Guid("c601ae41-3865-4ba3-aa5a-1b8ae16d9278"),
                            Email = "john.smith@js.com",
                            Name = "John",
                            Surname = "Smith"
                        });
                });

            modelBuilder.Entity("CarDealership.Model.Entities.Ad", b =>
                {
                    b.HasOne("CarDealership.Model.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });
#pragma warning restore 612, 618
        }
    }
}
