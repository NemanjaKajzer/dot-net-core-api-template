using System;
using System.ComponentModel.DataAnnotations;
using CarDealership.Common.Enums;

namespace CarDealership.Common.DTOs
{
    public class AdCreationDTO
    {
        public AdCreationDTO()
        {
            
        }

        public int Id { get; set; }

        public int CarId { get; set; }

        [Required]
        public int SellerId { get; set; }

        public int Price { get; set; }

        public Currency Currency { get; set; }

        public string Description { get; set; }
    }
}