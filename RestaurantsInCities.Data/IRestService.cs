using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantsInCities.Data.Models;

namespace RestaurantsInCities.Data
{
    public interface IRestService
    {
        Task<int> AddCityAsync(City city);
        Task<City> GetCityByIdAsync(int id);
        Task<int> AddRestaurantAsync(Restaurant restaurant);
        Task<IEnumerable<Restaurant>> GetAllRestaurantsInCityAsync(int cityId, PagingParams pagingParams);
        Task<Restaurant> GetRestaurantByIdAsync(int id);
    }
}