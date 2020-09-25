using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantsInCities.Data;
using RestaurantsInCities.Data.Models;

namespace RestaurantsInCities.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RestaurantService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int id)
        {
            return await _unitOfWork.RestaurantRepository.GetByIdAsync(id);
        }

        public async Task<int> AddRestaurantAsync(Restaurant restaurant)
        {
            var city = await _unitOfWork.CityRepository.GetWithRestaurantsByIdAsync(restaurant.City.Id);
            restaurant.City = city;
            await _unitOfWork.RestaurantRepository.AddAsync(restaurant);
            return await _unitOfWork.SaveAsync();
        }
    }
}