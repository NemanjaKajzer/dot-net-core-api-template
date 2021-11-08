using CarDealership.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CarDealership.Model.Entities
{
    [Table("Discount")]
    public class Discount
    {
        public Discount() { }

        public Discount(int id, string description, int value)
        {
            Id = id;
            PromoCode = description;
            Value = value;
        }

        [Key]
        public int Id { get; set; }

        public DiscountTypes Type { get; set; }

        public string PromoCode { get; set; }

        public int Value { get; set; }

    }
}