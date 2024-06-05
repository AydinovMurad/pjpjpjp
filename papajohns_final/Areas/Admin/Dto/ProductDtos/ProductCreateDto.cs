using papajohns_final.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace papajohns_final.Areas.Admin.Dto.ProductDtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public List<IFormFile>? Files { get; set; }

        public decimal Price { get; set; }
        public List<IFormFile> AdditionalFiles { get; set; } = new();
        public string SubCategory { get; set; }

        public int? CategoryId { get; set; }
        public Category? category { get; set; }
    }
}
