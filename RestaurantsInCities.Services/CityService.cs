using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantsInCities.Data;
using RestaurantsInCities.Data.Models;

namespace RestaurantsInCities.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<City> AddCityAsync(City city)
        {
            await _unitOfWork.CityRepository.AddAsync(city);
            await _unitOfWork.SaveAsync();
            return city;
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            return await _unitOfWork.CityRepository.GetWithRestaurantsByIdAsync(id);
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsInCityAsync(int cityId, PagingParams pagingParams)
        {
            return await _unitOfWork.CityRepository.GetAllRestaurantsInCityAsync(cityId, pagingParams);
        }
    }
}