using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantsInCities.Data.Models;

namespace RestaurantsInCities.Data
{
    public interface ICityService
    {
        Task<City> AddCityAsync(City city);
        Task<City> GetCityByIdAsync(int id);
        Task<IEnumerable<Restaurant>> GetAllRestaurantsInCityAsync(int cityId, PagingParams pagingParams);
    }
}