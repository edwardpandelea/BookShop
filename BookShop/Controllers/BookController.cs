using BookShop.Models;
using BookShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IActionResult List()
        {
            BookListViewModel bookListViewModel = new BookListViewModel(_bookRepository.GetAll, "All Books");
            return View(bookListViewModel);
        }

        public IActionResult Details(int id)
        {
            var book = _bookRepository.getBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
    }
}
