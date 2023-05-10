using Microsoft.AspNetCore.Mvc;

namespace ProniaTemplate.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
