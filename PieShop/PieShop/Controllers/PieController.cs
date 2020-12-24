using Microsoft.AspNetCore.Mvc;
using PieShop.Models;

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
            return View(_pieRepository.Pies);
        }
    }
}
