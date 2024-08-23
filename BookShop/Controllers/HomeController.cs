using BookShop.Models;
using BookShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public HomeController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            var mostSoldBooks = _bookRepository.MostSoldBooks;
            var homeViewModel = new HomeViewModel(mostSoldBooks);
            return View(homeViewModel);
        }
    }
}
