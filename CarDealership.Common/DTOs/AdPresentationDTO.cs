using System;
using System.ComponentModel.DataAnnotations;
using CarDealership.Common.Enums;

namespace CarDealership.Common.DTOs
{
    public class AdPresentationDTO
    {
        public AdPresentationDTO()
        {
            
        }

        public int Id { get; set; }

        public CarDTO Car { get; set; }

        [Required]
        public SellerDTO Seller { get; set; }

        public int Price { get; set; }

        public Currency Currency { get; set; }

        public string Description { get; set; }
    }
}