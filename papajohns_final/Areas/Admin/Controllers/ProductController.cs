using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using papajohns_final.Areas.Admin.Dto.ProductDtos;
using papajohns_final.Data;
using papajohns_final.Models;

namespace papajohns_final.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IActionResult> Index4(int? categoryId)
    {
        if (categoryId == null)
        {
            return View(await _context.Products.Include(p => p.category).Include(x=>x.ProductImages).ToListAsync());
        }

        var products = _context.Products
            .Where(p => p.CategoryId == categoryId)
            .Include(p => p.category).Include(x=>x.ProductImages);

        return View(await products.ToListAsync());
    }

    // GET: Product/Create
    public IActionResult Create()
    {
            ViewBag.Categories = _context.Categories.ToList();
        return View();
    }

    // POST: Product/Create
    [HttpPost]
    public async Task<IActionResult> Create(ProductPostDto dto)
    {
        ViewBag.Categories = _context.Categories.ToList();


        if(!ModelState.IsValid)
            return View(dto);


        Product product = new()
        {
            Name = dto.Name,
            Description = dto.Description,
            CategoryId = dto.CategoryId,
            Price = dto.Price,
            SubCategory=dto.SubCategory,
        };

        string path = Path.Combine(_webHostEnvironment.ContentRootPath,"wwwroot", "client", "assets", "images");
        foreach (var image in dto.ProductImages)
        {
            string filename = Guid.NewGuid() + image.FileName;
            string path2=Path.Combine(path,filename);
            using (FileStream stream = new(path2, FileMode.CreateNew))
            {
               
                await image.CopyToAsync(stream);
             }

            ProductImage ProductImage = new()
            {
                Product = product,
                Url = filename,

            };

            product.ProductImages.Add(ProductImage);
            
        }


        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();


        return RedirectToAction("Index4");



    }

    // GET: Product/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        ViewBag.Categories = _context.Categories.ToList();
        return View(product);
    }

    // POST: Product/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description,CategoryId,Image")] Product product)
    {
        if (id != product.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Categories = _context.Categories.ToList();
        return View(product);
    }

    // GET: Product/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _context.Products
            .Include(p => p.category)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // POST: Product/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var product = await _context.Products.FindAsync(id);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProductExists(int id)
    {
        return _context.Products.Any(e => e.Id == id);
    }
}
