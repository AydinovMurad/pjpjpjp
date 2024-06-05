using papajohns_final.Models;

namespace papajohns_final.Areas.Admin.Dto.ProductDtos
{
    public class ProductUpdateDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public List<IFormFile>? Files { get; set; }

        public decimal Price { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; } = null!;
        public string SubCategory { get; set; }

        public int? CategoryId { get; set; }
        public Category? category { get; set; }
    }
}
