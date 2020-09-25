using AutoMapper;
using RestaurantsInCities.Data.Models;
using RestaurantsInCities.WebApi.Dtos;

namespace RestaurantsInCities.WebApi.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityReadDto>();
            CreateMap<CityCreateDto, City>();
            CreateMap<CityReadRestDto, City>();
        }
    }
}