using Microsoft.AspNetCore.Mvc;

namespace papajohns_final.Areas.Admin.Controllers;
    [Area("Admin")]

    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

