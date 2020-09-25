using System.Collections.Generic;

namespace RestaurantsInCities.WebApi.Dtos
{
    public class CityReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RestaurantReadDto> Restaurants { get; set; }
    }

    public class CityReadRestDto
    {
        public int Id { get; set; }
    }
}