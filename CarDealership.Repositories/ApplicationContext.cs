﻿using CarDealership.Common.Enums;
using CarDealership.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarDealership.Repositories
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Discount>()
                 .HasData(
                     new Discount
                     {
                         Id = Guid.NewGuid(),
                         Description = "New customer",
                         Type = DiscountTypes.NEW_CUSTOMER,
                         Value = 100
                     },
                     new Discount
                     {
                         Id = Guid.NewGuid(),
                         Description = "Returning customer",
                         Type = DiscountTypes.RETURNING_CUSTOMER,
                         Value = 5
                     },
                     new Discount
                     {
                         Id = Guid.NewGuid(),
                         Description = "Black Friday",
                         Type = DiscountTypes.BLACK_FRIDAY,
                         Value = 10
                     },
                     new Discount
                     {
                         Id = Guid.NewGuid(),
                         Description = "No Discount",
                         Type = DiscountTypes.NO_DISCOUNT,
                         Value = 1
                     }
                 );

            var cars = new Car[] {
                new Car
                {
                    Id = Guid.NewGuid(),
                    Brand = "BMW",
                    Model = "520",
                    Power = 150,
                    Seats = 5,
                    Doors = 5,
                    ProductionYear = new DateTime(2020, 1, 1),
                    EngineVolume = 1999,
                    Kilometers = 100000,
                    TransmissionType = TransmissionType.Manual,
                },
                new Car
                {
                    Id = Guid.NewGuid(),
                    Brand = "Audi",
                    Model = "Q3",
                    Power = 170,
                    Seats = 5,
                    Doors = 5,
                    ProductionYear = new DateTime(2019, 1, 1),
                    EngineVolume = 1800,
                    Kilometers = 90000,
                    TransmissionType = TransmissionType.Automatic,
                },
                new Car
                {
                    Id = Guid.NewGuid(),
                    Brand = "ZASTAVA",
                    Model = "128",
                    Power = 200,
                    Seats = 5,
                    Doors = 5,
                    ProductionYear = new DateTime(1990, 1, 1),
                    EngineVolume = 2000,
                    Kilometers = 90000,
                    TransmissionType = TransmissionType.Automatic
                }
            };

            modelBuilder.Entity<Car>()
                .HasData(cars);

            modelBuilder.Entity<Ad>()
                .HasData(
                    new Ad
                    {
                        Id = Guid.NewGuid(),
                        CarId = cars[0].Id,
                        Currency = Currency.EUR,
                        Description = "Like new",
                        Price = 20000
                    }
                );



            modelBuilder.Entity<Seller>()
                .HasData(
                    new Seller
                    {
                        Id = Guid.NewGuid(),
                        Name = "John",
                        Surname = "Smith",
                        Email = "john.smith@js.com",
                    }
                );

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Discount> Discount { get; set; }
    }
}