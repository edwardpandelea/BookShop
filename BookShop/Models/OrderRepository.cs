namespace BookShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        public readonly BookShopDbContext _bookShopDbContext;
        public readonly IShoppingCart _shoppingCart;

        public OrderRepository(BookShopDbContext bookShopDbContext, IShoppingCart shoppingCart)
        {
            _bookShopDbContext = bookShopDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem> shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            order.orderDetails = new List<OrderDetail>();
            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    bookId = shoppingCartItem.Book.bookId,
                    Price = shoppingCartItem.Book.price
                };
                order.orderDetails.Add(orderDetail);
            }

            _bookShopDbContext.Orders.Add(order);
            _bookShopDbContext.SaveChanges();
        }
    }
}
