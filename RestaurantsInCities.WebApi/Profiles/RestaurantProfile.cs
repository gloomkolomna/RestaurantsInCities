using AutoMapper;
using RestaurantsInCities.Data.Models;
using RestaurantsInCities.WebApi.Dtos;

namespace RestaurantsInCities.WebApi.Profiles
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Restaurant, RestaurantReadDto>();
            CreateMap<RestaurantCreateDto, Restaurant>();
        }
    }
}