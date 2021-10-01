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

        public Ad(Guid id, Car car, string description)
        {
            Id = id;
            Car = car;
            Description = description;
        }

        [Key]
        public Guid Id { get; set; }

        public Guid CarId { get; set; }
        public Car Car { get; set; }

        public int Price { get; set; }

        public Currency Currency { get; set; }

        public string Description { get; set; }
    }
}