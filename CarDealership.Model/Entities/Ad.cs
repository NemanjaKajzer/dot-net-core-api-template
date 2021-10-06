using CarDealership.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarDealership.Common.DTOs;

namespace CarDealership.Model.Entities
{
    [Table("Ad")]
    public class Ad
    {
        public Ad() { }

        public Ad(AdPresentationDTO adDTO)
        {
            Description = adDTO.Description;
            Price = adDTO.Price;
            Currency = 0;
            Car = new Car
            {
                Brand = adDTO.Car.Brand,
                Model = adDTO.Car.Model,
                Power = adDTO.Car.Power,
                Seats = adDTO.Car.Seats,
                Doors = adDTO.Car.Doors,
                ProductionYear = adDTO.Car.ProductionYear,
                EngineVolume = adDTO.Car.EngineVolume,
                Kilometers = adDTO.Car.Kilometers,
                TransmissionType = adDTO.Car.TransmissionType
            };
        }

        public Ad(AdCreationDTO adCreationDTO)
        {
            Description = adCreationDTO.Description;
            Price = adCreationDTO.Price;
            Currency = adCreationDTO.Currency;
        }

        public Ad(Guid id, Car car, string description)
        {
            Id = id;
            Car = car;
            Description = description;
        }

        [Key]
        public Guid Id { get; set; }

        [ForeignKey("CarId")]
        public Car Car { get; set; }

        public Seller Seller { get; set; }

        public int Price { get; set; }

        public Currency Currency { get; set; }

        public string Description { get; set; }
    }
}