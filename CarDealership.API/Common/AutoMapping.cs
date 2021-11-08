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
            CreateMap<Ad, AdPresentationDTO>();
            CreateMap<Seller, SellerDTO>();

            CreateMap<CarDTO, Car>();
            CreateMap<AdCreationDTO, Ad>();
            CreateMap<AdPresentationDTO, Ad>();
            CreateMap<SellerDTO, Seller>();

            CreateMap<int, Car>().ConvertUsing<ITypeConverter<int, Car>>();
            CreateMap<int, Ad>().ConvertUsing<ITypeConverter<int, Ad>>();
            CreateMap<int, Seller>().ConvertUsing<ITypeConverter<int, Seller>>();
        }
    }
}