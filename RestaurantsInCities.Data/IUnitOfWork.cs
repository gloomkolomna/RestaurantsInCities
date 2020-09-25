using System;
using System.Threading.Tasks;
using RestaurantsInCities.Data.Repositories;

namespace RestaurantsInCities.Data
{
    public interface IUnitOfWork : IDisposable
    {
        ICityRepository CityRepository { get; }
        IRestaurantRepository RestaurantRepository { get; }
        Task<int> SaveAsync();
    }
}