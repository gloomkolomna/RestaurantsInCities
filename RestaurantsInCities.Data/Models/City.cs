using System.Collections.Generic;

namespace RestaurantsInCities.Data.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}