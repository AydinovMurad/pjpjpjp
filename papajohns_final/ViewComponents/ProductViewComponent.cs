//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using papajohns_final.Data;

//namespace papajohns_final.ViewComponents
//{
//        public class ProductViewComponent : ViewComponent
//        {
//            private readonly AppDbContext _context;

//            public ProductViewComponent(AppDbContext context)
//            {
//                _context = context;
//            }

//            public async Task<IViewComponentResult> InvokeAsync(int? categoryId, string productName, int page = 1, int pageSize = 1)
//            {
//                var products = _context.Products
//                    .Include(x => x.category)
//                    .Include(x => x.ProductImages);

//                var count = GetPageCount(pageSize);
//                if (categoryId == null)
//                {
//                    var orderedWithCatProducts = await products.Skip((page - 1) * pageSize)
//                                                               .Take(pageSize)
//                                                               .OrderByDescending(x => x.Id)
//                                                               .ToListAsync();
//                }
//                var orderedProducts = await products.Skip((page - 1) * pageSize)
//                                                        .Take(pageSize)
//                                                        .Where(x => x.CategoryId == categoryId)
//                                                        .OrderByDescending(x => x.Id)
//                                                        .ToListAsync();
//            }

//            public int GetPageCount(int pageSize)
//            {
//                var productCount = _context.Products.Count();
//                return (int)Math.Ceiling((decimal)productCount / pageSize);
//            }
//        }
//    }

