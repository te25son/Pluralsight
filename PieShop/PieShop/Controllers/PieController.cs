using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.ViewModels;

namespace PieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;

        private readonly ICategoryRepository _categoryRepository;  

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List()
        {
            var pieListViewModel = new PieListViewModel
            {
                Pies = _pieRepository.Pies,
                CurrentCategory = "Cheese cakes"
            };

            return View(pieListViewModel);
        }
    }
}
