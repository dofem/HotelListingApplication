using AutoMapper;
using HotelListing.Application.Dto.ApiUser;
using HotelListing.Application.Dto.Country;
using HotelListing.Application.Dto.Hotel;
using HotelListing.Domain.Model;

namespace HotelListing.API.Helper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, GetCountryDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();
            CreateMap<UpdateCountryDto, Country>();

            CreateMap<BaseCountryDto, Country>()
                        .Include<UpdateCountryDto, Country>();


            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Hotel, UpdateHotelDto>().ReverseMap();
            CreateMap<Hotel, CreateHotelDto>().ReverseMap();

            CreateMap<ApiUser, RegisterDto>().ReverseMap();
        }
    }
}
