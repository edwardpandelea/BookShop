namespace BookShop.Models
{
    public interface IBookRepository
    {
       public IEnumerable<Book> GetAll { get; }
       public Book? getBookById(int id);

    }
}
