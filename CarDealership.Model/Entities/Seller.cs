using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarDealership.Common.DTOs;

namespace CarDealership.Model.Entities
{
    [Table("Seller")]
    public class Seller
    {
        public Seller() { }

        public Seller(SellerDTO sellerDTO)
        {
            Id = sellerDTO.Id;
            Name = sellerDTO.Name;
            Surname = sellerDTO.Surname;
            Email = sellerDTO.Email;
        }

        public Seller(Guid id, string name, string surname, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public List<Ad> Ads { get; set; }
    }
}