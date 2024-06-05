using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using papajohns_final.Data;
using papajohns_final.Models;
using papajohns_final.ViewModels;

namespace papajohns_final.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? categoryId)
        {
            if (categoryId == null)
            {
                return View(await _context.Products.Include(p => p.category).ToListAsync());
            }

            var products = _context.Products
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.category);

            return View(await products.ToListAsync());
        }
    }
    //public class ProductController : Controller
    //{
    //    private readonly AppDbContext _context;

    //    public ProductController(AppDbContext context)
    //    {
    //        _context = context;
    //    }
    //    public async Task<IActionResult> Index()
    //    {
    //        var products = await _context.Products.ToListAsync();
    //        return View(products);
    //        var categories = await _context.Categories.Include(x =>x.Products).ToListAsync();
    //        ProductVm productsVm = new ProductVm()
    //        {
    //            Products = products,
    //            Categories = categories
    //        };
    //        return View(productsVm);
    //    }
    //    //    public async Task<IActionResult> Index(ProductSearchVm? vm, int page = 1, int pageSize = 1)
    //    //    {
    //    //        var products = _context.Products.AsQueryable();
    //    //        products = products
    //    //           .Include(x => x.category)
    //    //           .Include(x => x.ProductImages)
    //    //           .Skip((page - 1) * pageSize)
    //    //           .Take(pageSize);
    //    //        var count = GetPageCount(pageSize);
    //    //        //PaginateVm paginateVm = new PaginateVm()
    //    //        //{
    //    //        //    CurrentPage = page,
    //    //        //    TotalPageCount = count,
    //    //        //    Products = await products.ToListAsync()
    //    //        //};
    //    //        return View(products);
    //    //    }
    //    //    public int GetPageCount(int pageSize)
    //    //    {
    //    //        var productCount = _context.Products.Count();
    //    //        return (int)Math.Ceiling((decimal)productCount / pageSize);
    //    //    }

    //    //    public async Task<IActionResult> Detail(int? id)
    //    //    {
    //    //        if (id == null) return NotFound();
    //    //        var product = await _context.Products
    //    //           .Include(x => x.category)
    //    //           .Include(x => x.ProductImages)
    //    //           .FirstOrDefaultAsync(x => x.Id == id);

    //    //        if (product == null) return NotFound();
    //    //        var categories = await _context.Categories.Include(x => x.Products).ToListAsync();
    //    //        ProductVm productVm = new ProductVm()
    //    //        {
    //    //            Product = product,
    //    //            Categories = categories
    //    //        };
    //    //        return View(productVm);
    //    //    }

    //    //    //public async Task<IActionResult> AddToCart(int id)
    //    //    //{
    //    //    //    var existProduct = await _context.Products.AnyAsync(x => x.Id == id);
    //    //    //    if (!existProduct) return NotFound();

    //    //    //    List<BasketVm>? basketVm = GetBasket();
    //    //    //    BasketVm cartVm = basketVm.Find(x => x.Id == id);
    //    //    //    if (cartVm != null)
    //    //    //    {
    //    //    //        cartVm.Count++;
    //    //    //    }
    //    //    //    else
    //    //    //    {
    //    //    //        basketVm.Add(new BasketVm
    //    //    //        {
    //    //    //            Count = 1,
    //    //    //            Id = id
    //    //    //        });
    //    //    //    }

    //    //    //    Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketVm));
    //    //    //    return RedirectToAction("Index");
    //    //    //}
    //    //    //private List<BasketVm> GetBasket()
    //    //    //{
    //    //    //    List<BasketVm> basketVms;
    //    //    //    if (Request.Cookies["basket"] != null)
    //    //    //    {
    //    //    //        basketVms = JsonConvert.DeserializeObject<List<BasketVm>>(Request.Cookies["basket"]);
    //    //    //    }
    //    //    //    else basketVms = new List<BasketVm>();
    //    //    //    return basketVms;
    //    //    //}

    //    //    public IActionResult ChangePage(int page = 1, int pageSize = 1)
    //    //    {
    //    //        return ViewComponent("Product", new { page = page, pageSize = pageSize });
    //    //    }
    //    //}


    //}

}