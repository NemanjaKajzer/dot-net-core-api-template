using CarDealership.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Model.Entities
{
    [Table("Ad")]
    public class Ad
    {
        public Ad() { }

        public Ad(int id, Car car, string description)
        {
            Id = id;
            Car = car;
            Description = description;
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("CarId")]
        public Car Car { get; set; }

        public Seller Seller { get; set; }

        public int Price { get; set; }

        public Currency Currency { get; set; }

        public string Description { get; set; }
    }
}