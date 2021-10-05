using System;
using System.ComponentModel.DataAnnotations;
using CarDealership.Common.DTOs;
using CarDealership.Common.Enums;

namespace CarDealership.Model.Entities
{
    public class Car
    {
        public Car() { }

        public Car(CarDTO carDto)
        {
            Brand = carDto.Brand;
            Model = carDto.Model;
            Power = carDto.Power;
            Seats = carDto.Seats;
            Doors = carDto.Doors;
            ProductionYear = carDto.ProductionYear;
            EngineVolume = carDto.EngineVolume;
            Kilometers = carDto.Kilometers;
            TransmissionType = carDto.TransmissionType;
        }

        public Car(Guid id, string brand, string model, int power, int seats, int doors, DateTime productionYear, int engineVolume, int kilometers, TransmissionType transmissionType)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Power = power;
            Seats = seats;
            Doors = doors;
            ProductionYear = productionYear;
            EngineVolume = engineVolume;
            Kilometers = kilometers;
            TransmissionType = transmissionType;
        }

        [Key]
        public Guid Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Power { get; set; }

        public int Seats { get; set; }

        public int Doors { get; set; }

        public DateTime ProductionYear { get; set; }

        public int EngineVolume { get; set; }

        public int Kilometers { get; set; }

        public TransmissionType TransmissionType { get; set; }

    }
}