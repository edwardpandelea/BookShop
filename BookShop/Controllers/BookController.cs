using BookShop.Models;
using BookShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;

        public BookController(IBookRepository bookRepository, IGenreRepository genreRepository)
        {
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
        }
        //public IActionResult List()
        //{
        //    BookListViewModel bookListViewModel = new BookListViewModel(_bookRepository.GetAll, "All Books");
        //    return View(bookListViewModel);
        //}

        public IActionResult List(string genre)
        {
            IEnumerable<Book> books;
            string? currentGenre;
            if (string.IsNullOrEmpty(genre))
            {
                books = _bookRepository.GetAll.OrderBy(b => b.bookId);
                currentGenre = "All Books";
            }
            else
            {
                books = _bookRepository.GetAll.Where(b=>b.genre.genreName == genre).OrderBy(b => b.bookId);
                currentGenre = _genreRepository.allGenres.FirstOrDefault(g => g.genreName == genre)?.genreName;
            }
            return View(new BookListViewModel(books, currentGenre));
        }

        public IActionResult Details(int id)
        {
            var book = _bookRepository.getBookById(id);
            book.genre = _genreRepository.getGenreById(book.GenreId);
            if (book == null)
            {
                return NotFound(); 
            }

            return View(book);
        }
    }
}
