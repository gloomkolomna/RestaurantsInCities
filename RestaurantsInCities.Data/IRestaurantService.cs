using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantsInCities.Data.Models;

namespace RestaurantsInCities.Data
{
    public interface IRestaurantService
    {
        Task<int> AddRestaurantAsync(Restaurant restaurant);
        Task<Restaurant> GetRestaurantByIdAsync(int id);
    }
}