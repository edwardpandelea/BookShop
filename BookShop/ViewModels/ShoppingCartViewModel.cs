using BookShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.ViewModels
{
    public class ShoppingCartViewModel : Controller
    {
        public ShoppingCartViewModel(IShoppingCart shoppingCart, decimal shoppingCartTotal) { 
            ShoppingCart = shoppingCart;
            ShoppingCartTotal = shoppingCartTotal;
        
        }
        public IShoppingCart ShoppingCart { get;  }
        public decimal ShoppingCartTotal { get; }
    }
}
