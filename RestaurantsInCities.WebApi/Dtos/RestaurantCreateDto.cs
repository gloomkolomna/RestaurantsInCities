namespace RestaurantsInCities.WebApi.Dtos
{
    public class RestaurantCreateDto
    {
        public string Name { get; set; }
        public CityReadRestDto City { get; set; }
    }
}