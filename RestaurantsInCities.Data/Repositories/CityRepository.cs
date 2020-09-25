using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantsInCities.Data.Models;

namespace RestaurantsInCities.Data.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private readonly EfDataContext _context;

        public CityRepository(EfDataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<City> GetWithRestaurantsByIdAsync(int id)
        {
            return await _context.Cities.Include(r => r.Restaurants).FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsInCityAsync(int cityId, PagingParams pagingParams)
        {
            var city = await GetWithRestaurantsByIdAsync(cityId);
            return city?.Restaurants
                .OrderBy(r => r.Name)
                .Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                .Take(pagingParams.PageSize)
                .ToList();
        }
    }
}