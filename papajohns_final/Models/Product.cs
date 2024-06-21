using System.ComponentModel.DataAnnotations.Schema;

namespace papajohns_final.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        [NotMapped]
        public List<IFormFile>? Files { get; set; }

        public decimal Price { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public string SubCategory { get; set; }

        public int? CategoryId { get; set; }
        public Category? category { get; set; } 
    }
}
