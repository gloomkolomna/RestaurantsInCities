using System.ComponentModel.DataAnnotations;

namespace RestaurantsInCities.WebApi.Dtos
{
    public class CityCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}