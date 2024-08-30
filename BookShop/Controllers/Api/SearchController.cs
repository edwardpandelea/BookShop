using BookShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public SearchController(IBookRepository bookRepository)
        {
                _bookRepository = bookRepository;
        }
       
        [HttpGet]
        public IActionResult GetAll()
        {
            var allBooks = _bookRepository.GetAll;
            return Ok(allBooks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_bookRepository.GetAll.Any(b=>b.bookId == id))
            {
                return NotFound();
            }

            return Ok(_bookRepository.GetAll.Where(b=>b.bookId == id));
        }

        [HttpPost]
        public IActionResult SearchBooks([FromBody]string searchQuery)
        {
            IEnumerable<Book> books = new List<Book>();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                books = _bookRepository.searchBooks(searchQuery);
            }
            if (!books.Any())
            {
                return NotFound();
            }
            return new JsonResult(books);
        }

    }
}
