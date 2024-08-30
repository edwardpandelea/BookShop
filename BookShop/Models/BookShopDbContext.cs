using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Models
{
    public class BookShopDbContext: IdentityDbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options) : base(options) { }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
