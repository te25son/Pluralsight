using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurdantData;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string Message { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurdantData)
        {
            this.config = config;
            this.restaurdantData = restaurdantData;
        }

        public void OnGet()
        {
            Message = config["Message"];
            Restaurants = restaurdantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
