using System;
using CarDealership.Common.Enums;

namespace CarDealership.Common.DTOs
{
    public class AdDTO
    {
        public AdDTO()
        {
            
        }
        public Guid Id { get; set; }

        public CarDTO Car { get; set; }

        public int Price { get; set; }

        public Currency Currency { get; set; }

        public string Description { get; set; }
    }
}