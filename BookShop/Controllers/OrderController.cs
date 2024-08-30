using BookShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        public readonly IOrderRepository _orderRepository;
        public readonly IShoppingCart shoppingCart;


        public OrderController(IOrderRepository orderRepository, IShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            this.shoppingCart = shoppingCart;
        }

        [HttpGet]
        public IActionResult Checkout() //GET
        {

            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;
            if (shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first!");
            }
            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);

        }

        public IActionResult CheckoutComplete()
        {
            return View();
        }

    }
}
