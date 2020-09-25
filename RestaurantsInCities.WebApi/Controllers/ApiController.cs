using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantsInCities.Data;
using RestaurantsInCities.Data.Models;
using RestaurantsInCities.WebApi.Dtos;

namespace RestaurantsInCities.WebApi.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ApiController : ControllerBase
    {
        private readonly IRestService _restService;
        private readonly IMapper _mapper;

        public ApiController(IRestService restService, IMapper mapper)
        {
            _restService = restService;
            _mapper = mapper;
        }

        [HttpGet("city/{id}/allRestaurants", Name = "GetAllRestaurantsInCity")]
        public async Task<ActionResult<RestaurantReadDto>> GetAllRestaurantsInCity(int id, [FromQuery] PagingParams pagingParams)
        {
            // var city = await _restService.GetCityByIdAsync(id);
            // if (city == null)
            //     return NotFound();
            
            var restaurants = await _restService.GetAllRestaurantsInCityAsync(id, pagingParams);
            if (restaurants == null)
                return NoContent();
            
            return Ok(_mapper.Map<IEnumerable<RestaurantReadDto>>(restaurants));
        }

        [HttpGet("city/{id}", Name = "GetCityById")]
        public async Task<ActionResult<CityReadDto>> GetCityById(int id)
        {
            var city = await _restService.GetCityByIdAsync(id);
            if (city == null)
                return NotFound();

            return Ok(_mapper.Map<CityReadDto>(city));
        }
        
        [HttpGet("restaurant/{id}", Name = "GetRestaurantById")]
        public async Task<ActionResult<RestaurantReadDto>> GetRestaurantById(int id)
        {
            var restaurant = await _restService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
                return NotFound();

            return Ok(_mapper.Map<RestaurantReadDto>(restaurant));
        }

        [HttpPost("city")]
        public async Task<ActionResult<CityReadDto>> CreateCity(CityCreateDto cityCreateDto)
        {
            var cityModel = _mapper.Map<City>(cityCreateDto);
            await _restService.AddCityAsync(cityModel);

            var cityReadDto = _mapper.Map<CityReadDto>(cityModel);
            return CreatedAtRoute(nameof(GetCityById), new {cityReadDto.Id}, cityReadDto);
        }

        [HttpPost("city/restaurant")]
        public async Task<ActionResult<RestaurantReadDto>> CreateRestaurant(RestaurantCreateDto restaurantCreateDto)
        {
            var restaurantModel = _mapper.Map<Restaurant>(restaurantCreateDto);
            await _restService.AddRestaurantAsync(restaurantModel);

            var restaurantReadDto = _mapper.Map<RestaurantReadDto>(restaurantModel);
            return CreatedAtRoute(nameof(GetRestaurantById), new {restaurantReadDto.Id}, restaurantReadDto);
        }
    }
}