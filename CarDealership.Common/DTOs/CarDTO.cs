using System;
using CarDealership.Common.Enums;

namespace CarDealership.Common.DTOs
{
    public class CarDTO
    {
        public CarDTO() { }

        public Guid Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Power { get; set; }

        public int Seats { get; set; }

        public int Doors { get; set; }

        public int ProductionYear { get; set; }

        public int EngineVolume { get; set; }

        public int Kilometers { get; set; }

        public TransmissionType TransmissionType { get; set; }
    }
}