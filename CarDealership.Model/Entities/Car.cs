using CarDealership.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Model.Entities
{
    public class Car
    {
        public Car() { }

        public Car(int id, string brand, string model, int power, int seats, int doors, int productionYear, int engineVolume, int kilometers, TransmissionType transmissionType)
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
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Power { get; set; }

        public int Seats { get; set; }

        public int Doors { get; set; }

        public int EngineVolume { get; set; }

        public int Kilometers { get; set; }

        public int ProductionYear { get; set; }

        public TransmissionType TransmissionType { get; set; }

    }
}