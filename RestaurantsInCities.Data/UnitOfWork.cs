using System.Threading.Tasks;
using RestaurantsInCities.Data.Repositories;

namespace RestaurantsInCities.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EfDataContext _context;
        private CityRepository _cityRepo;
        private RestaurantRepository _restaurantRepo;

        public UnitOfWork(EfDataContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public ICityRepository CityRepository => _cityRepo ??= new CityRepository(_context);
        public IRestaurantRepository RestaurantRepository => _restaurantRepo ??= new RestaurantRepository(_context);
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}