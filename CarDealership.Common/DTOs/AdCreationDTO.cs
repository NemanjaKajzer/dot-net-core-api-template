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

        public Guid Id { get; set; }

        public Guid CarId { get; set; }

        public Guid DiscountId { get; set; }

        [Required]
        public Guid SellerId { get; set; }

        public int Price { get; set; }

        public Currency Currency { get; set; }

        public string Description { get; set; }
    }
}