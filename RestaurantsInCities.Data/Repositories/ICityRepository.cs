using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantsInCities.Data.Models;

namespace RestaurantsInCities.Data.Repositories
{
    public interface ICityRepository : IRepository<City>
    {
        Task<City> GetWithRestaurantsByIdAsync(int id);
        Task<IEnumerable<Restaurant>> GetAllRestaurantsInCityAsync(int cityId, PagingParams pagingParams);
    }
}