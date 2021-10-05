using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarDealership.Common.Enums;


namespace CarDealership.Model.Entities
{
    [Table("Discount")]
    public class Discount
    {
        public Discount() { }

        public Discount(Guid id, string description, int value)
        {
            Id = id;
            PromoCode = description;
            Value = value;
        }

        [Key]
        public Guid Id { get; set; }

        public DiscountTypes Type { get; set; }

        public string PromoCode { get; set; }

        public int Value { get; set; }

        public List<Ad> Ads { get; set; }

    }
}