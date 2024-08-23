using Microsoft.EntityFrameworkCore;

namespace BookShop.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly BookShopDbContext _bookShopDbContext;

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        private ShoppingCart(BookShopDbContext bookShopDbContext)
        {
            _bookShopDbContext = bookShopDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            BookShopDbContext context = services.GetService<BookShopDbContext>() ?? throw new Exception("Error initializing");
            string cardId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();
            session?.SetString("CartId", cardId);
            return new ShoppingCart(context) { ShoppingCartId = cardId };
        }

        public void AddToCart(Book book)
        {
            var shoppingCartItem = _bookShopDbContext.ShoppingCartItems.SingleOrDefault(s => s.Book.bookId == book.bookId && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Book = book,
                    Amount = 1
                };

                _bookShopDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _bookShopDbContext.SaveChanges();
        }

        public int RemoveFromCart(Book book)
        {
            var shoppingCartItem = _bookShopDbContext.ShoppingCartItems.SingleOrDefault(s => s.Book.bookId == book.bookId && s.ShoppingCartId == ShoppingCartId);
            var localAmount = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _bookShopDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _bookShopDbContext.SaveChanges();
            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??= _bookShopDbContext.ShoppingCartItems.Where(c=>c.ShoppingCartId==ShoppingCartId).Include(s =>s.Book).ToList();
        }

        public void ClearCart()
        {
            var cartItems = _bookShopDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);
            _bookShopDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _bookShopDbContext.SaveChanges();
        }
        public decimal GetShoppingCartTotal()
        {
            var total = _bookShopDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Select(c => c.Book.price * c.Amount).Sum();
            return Math.Round(total,2);

        }
    }
}
