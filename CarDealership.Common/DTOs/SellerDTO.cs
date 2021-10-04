using System;

namespace CarDealership.Common.DTOs
{
    public class SellerDTO
    {
        public SellerDTO()
        {
            
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
    }
}