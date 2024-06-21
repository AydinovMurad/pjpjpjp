using Microsoft.AspNetCore.Mvc;

namespace papajohns_final.Controllers
{
    public class RestraurantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
