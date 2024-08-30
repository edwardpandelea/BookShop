namespace BookShop.Models
{
    public interface IBookRepository
    {
       public IEnumerable<Book> GetAll { get; }
       public Book? getBookById(int id);
       public IEnumerable<Book> MostSoldBooks { get; }
       public IEnumerable<Book> searchBooks(string searchQuery);
    }
}
