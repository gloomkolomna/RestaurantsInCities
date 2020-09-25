using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantsInCities.Data;
using RestaurantsInCities.Data.Models;
using RestaurantsInCities.WebApi.Dtos;

namespace RestaurantsInCities.WebApi.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IMapper mapper, IRestaurantService restaurantService)
        {
            _mapper = mapper;
            _restaurantService = restaurantService;
        }
        
        [HttpGet("{id}", Name = "GetRestaurantById")]
        public async Task<ActionResult<RestaurantReadDto>> GetRestaurantById(int id)
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
                return NotFound();

            return Ok(_mapper.Map<RestaurantReadDto>(restaurant));
        }
        
        [HttpPost()]
        public async Task<ActionResult<RestaurantReadDto>> CreateRestaurant(RestaurantCreateDto restaurantCreateDto)
        {
            var restaurantModel = _mapper.Map<Restaurant>(restaurantCreateDto);
            await _restaurantService.AddRestaurantAsync(restaurantModel);

            var restaurantReadDto = _mapper.Map<RestaurantReadDto>(restaurantModel);
            return CreatedAtRoute(nameof(GetRestaurantById), new {restaurantReadDto.Id}, restaurantReadDto);
        }
    }
}