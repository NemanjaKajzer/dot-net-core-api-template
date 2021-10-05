using AutoMapper;
using CarDealership.Common.DTOs;
using CarDealership.Model.Entities;

namespace CarDealership.API.Common
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Car, CarDTO>();
            CreateMap<Ad, AdCreationDTO>();
            CreateMap<Seller, SellerDTO>();
        }
    }
}