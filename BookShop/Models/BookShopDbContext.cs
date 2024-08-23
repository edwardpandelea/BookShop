using Microsoft.EntityFrameworkCore;

namespace BookShop.Models
{
    public class BookShopDbContext: DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options) : base(options) { }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
