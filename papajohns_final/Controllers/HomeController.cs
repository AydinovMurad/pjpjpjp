using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using papajohns_final.Data;

namespace papajohns_final.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
