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
    public class CityController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICityService _cityService;

        public CityController(IMapper mapper, ICityService cityService)
        {
            _mapper = mapper;
            _cityService = cityService;
        }
        
        [HttpGet("{id}/allRestaurants", Name = "GetAllRestaurantsInCity")]
        public async Task<ActionResult<RestaurantReadDto>> GetAllRestaurantsInCity(int id, [FromQuery] PagingParams pagingParams)
        {
            var city = await _cityService.GetCityByIdAsync(id);
            if (city == null)
                return NotFound();
            
            var restaurants = await _cityService.GetAllRestaurantsInCityAsync(id, pagingParams);
            if (restaurants == null)
                return NoContent();
            
            return Ok(_mapper.Map<IEnumerable<RestaurantReadDto>>(restaurants));
        }

        [HttpGet("{id}", Name = "GetCityById")]
        public async Task<ActionResult<CityReadDto>> GetCityById(int id)
        {
            var city = await _cityService.GetCityByIdAsync(id);
            if (city == null)
                return NotFound();

            return Ok(_mapper.Map<CityReadDto>(city));
        }
        
        [HttpPost()]
        public async Task<ActionResult<CityReadDto>> CreateCity(CityCreateDto cityCreateDto)
        {
            var cityModel = _mapper.Map<City>(cityCreateDto);
            await _cityService.AddCityAsync(cityModel);

            var cityReadDto = _mapper.Map<CityReadDto>(cityModel);
            return CreatedAtRoute(nameof(GetCityById), new {cityReadDto.Id}, cityReadDto);
        }
    }
}