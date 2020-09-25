namespace RestaurantsInCities.Data.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual City City { get; set; }
    }
}