using BookShop.Models;

namespace BookShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Book> mostSoldBooks { get; }

        public HomeViewModel(IEnumerable<Book> MostSoldBooks) { 
            mostSoldBooks = MostSoldBooks;
        
        }

    }
}
