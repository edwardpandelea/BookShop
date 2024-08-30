
using Microsoft.EntityFrameworkCore;

namespace BookShop.Models
{
    public class BookRepository : IBookRepository
    {
        private readonly BookShopDbContext _bookShopDbContext;
        public BookRepository(BookShopDbContext bookShopDbContext)
        {
            _bookShopDbContext = bookShopDbContext;
        }
        public IEnumerable<Book> GetAll
        {
            get
            {
                return _bookShopDbContext.Books.Include(b => b.genre);
            }
        }

        public IEnumerable <Book> MostSoldBooks
        {
            get
            {
                return _bookShopDbContext.Books.Include(g=>g.genre).Where(b=>b.IsMostSoldBook);
            }
        }

        public Book? getBookById(int bookId)
        {
            return _bookShopDbContext.Books.FirstOrDefault(b => b.bookId == bookId);
        }

        public IEnumerable<Book> searchBooks(string searchQuery)
        {
            return _bookShopDbContext.Books.Where(b=>b.title.Contains(searchQuery) || b.author.Contains(searchQuery) || b.genre.genreName.Contains(searchQuery));
        }
        
    }
}
