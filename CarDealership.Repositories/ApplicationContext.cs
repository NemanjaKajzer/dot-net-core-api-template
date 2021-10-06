using CarDealership.Common.Enums;
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
            modelBuilder.Entity<Ad>().HasOne(a => a.Car);

            modelBuilder.Entity<Discount>()
                .HasData(
                    new Discount
                    {
                        Id = Guid.NewGuid(),
                        PromoCode = "NEW",
                        Type = DiscountTypes.NEW_CUSTOMER,
                        Value = 100
                    },
                    new Discount
                    {
                        Id = Guid.NewGuid(),
                        PromoCode = "RETURN",
                        Type = DiscountTypes.RETURNING_CUSTOMER,
                        Value = 5
                    },
                    new Discount
                    {
                        Id = Guid.NewGuid(),
                        PromoCode = "BF2021",
                        Type = DiscountTypes.BLACK_FRIDAY,
                        Value = 10
                    },
                    new Discount
                    {
                        Id = Guid.NewGuid(),
                        PromoCode = "No Discount",
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
                    ProductionYear = 2000,
                    EngineVolume = 1999,
                    Kilometers = 100000,
                    TransmissionType = TransmissionType.MANUAL,
                },
                new Car
                {
                    Id = Guid.NewGuid(),
                    Brand = "Audi",
                    Model = "Q3",
                    Power = 170,
                    Seats = 5,
                    Doors = 5,
                    ProductionYear = 2010,
                    EngineVolume = 1800,
                    Kilometers = 90000,
                    TransmissionType = TransmissionType.AUTOMATIC,
                }
            };

            modelBuilder.Entity<Car>()
                .HasData(cars);


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