using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantsInCities.Data.Models;

namespace RestaurantsInCities.Data.Repositories
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        private readonly EfDataContext _context;

        public RestaurantRepository(EfDataContext context) : base(context)
        {
            _context = context;
        }
    }
}