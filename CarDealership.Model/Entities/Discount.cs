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

        public Discount(Guid id, string description, int value)
        {
            Id = id;
            Description = description;
            Value = value;
        }

        [Key]
        public Guid Id { get; set; }

        public DiscountTypes Type { get; set; }

        public string Description { get; set; }

        public int Value { get; set; }

    }
}