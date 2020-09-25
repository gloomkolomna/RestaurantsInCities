using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantsInCities.Data;
using RestaurantsInCities.Data.Models;

namespace RestaurantsInCities.Services
{
    public class RestService : IRestService
    {
        private readonly DataContext _context;

        public RestService(DataContext context)
        {
            _context = context;
        }

        public async Task<int> AddCityAsync(City city)
        {
            await _context.Cities.AddAsync(city);
            return await _context.SaveChangesAsync();
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            return await _context.Cities.Include(r => r.Restaurants).FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int id)
        {
            return await _context.Restaurants.FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<int> AddRestaurantAsync(Restaurant restaurant)
        {
            var city = await GetCityByIdAsync(restaurant.City.Id);
            restaurant.City = city;
            await _context.Restaurants.AddAsync(restaurant);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsInCityAsync(int cityId, PagingParams pagingParams)
        {
            var contextCity = await GetCityByIdAsync(cityId);

            return contextCity?.Restaurants
                .OrderBy(r => r.Name)
                .Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                .Take(pagingParams.PageSize)
                .ToList();
        }
    }
}