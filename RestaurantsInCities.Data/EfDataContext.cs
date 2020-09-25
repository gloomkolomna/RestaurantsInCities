using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantsInCities.Data.Models;

namespace RestaurantsInCities.Data
{
    public class EfDataContext : DbContext
    {
        public EfDataContext(DbContextOptions<EfDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().ToTable(nameof(City));
            modelBuilder.Entity<Restaurant>().ToTable(nameof(Restaurant));
        }
    }
}