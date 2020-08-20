﻿using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);

        Restaurant GetById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant {Id = 1, Name = "Frodo's Pizza", Location = "Shire", Cuisine = CuisineType.Italian },
                new Restaurant {Id = 2, Name = "Curry By Gimly", Location = "Mines of Moria", Cuisine = CuisineType.Indian },
                new Restaurant {Id = 3, Name = "Merry and Pippin's Taco Stand", Location = "Shire", Cuisine = CuisineType.Mexican },
                new Restaurant {Id = 4, Name = "Sauron's Sushi", Location = "Mordor", Cuisine = CuisineType.Japanese }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null) =>
            restaurants.Where(r => string.IsNullOrEmpty(name) || r.Name.StartsWith(name)).OrderBy(r => r.Name);

        public Restaurant GetById(int id) =>
            restaurants.SingleOrDefault(r => r.Id.Equals(id));
    }
}
