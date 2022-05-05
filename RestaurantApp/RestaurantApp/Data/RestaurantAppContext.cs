#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Models;

namespace RestaurantApp.Data
{
    public class RestaurantAppContext : DbContext
    {
        public RestaurantAppContext (DbContextOptions<RestaurantAppContext> options)
            : base(options)
        {
        }

        public DbSet<RestaurantApp.Models.Restaurant> Restaurant { get; set; }
    }
}
