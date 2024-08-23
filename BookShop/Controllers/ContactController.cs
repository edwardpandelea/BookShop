using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
