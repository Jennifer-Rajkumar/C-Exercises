using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantApp.Data;
using System;
using System.Linq;

namespace RestaurantApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RestaurantAppContext(serviceProvider.GetRequiredService<DbContextOptions<RestaurantAppContext>>()))
            {
                // Look for any movies.
                if (context.Restaurant.Any())
                {
                    return;   // DB has been seeded
                }

                context.Restaurant.AddRange(
                    new Restaurant
                    {
                        Name = "KFC",
                        Rating = 4.5f,
                        FoodType = "Non-Veg"
                    },

                    new Restaurant
                    {
                        Name = "McDonalds",
                        Rating = 4.3f,
                        FoodType = "Non-Veg"
                    },

                    new Restaurant
                    {
                        Name = "Dominos",
                        Rating = 4.6f,
                        FoodType = "Veg"
                    },

                    new Restaurant
                    {
                        Name = "Pizza Hut",
                        Rating = 4.2f,
                        FoodType = "Non-Veg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
