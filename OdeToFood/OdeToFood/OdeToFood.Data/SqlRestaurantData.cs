using OdeToFood.Core;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext Context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            Context = context;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            Context.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit() => Context.SaveChanges();

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                Context.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int id) => Context.Restaurants.Find(id);

        public IEnumerable<Restaurant> GetRestaurantsByName(string name) =>
            Context.Restaurants
                .Where(r => r.Name.StartsWith(name) || string.IsNullOrEmpty(name))
                .OrderBy(r => r.Name);

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = Context.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;

            return updatedRestaurant;
        }
    }
}
