using System.ComponentModel.DataAnnotations.Schema;

namespace papajohns_final.Models
{
    public class ProductImage : BaseEntity
    {
        public string Url { get; set; } = null!;
        [NotMapped]
        public IFormFile File { get; set; } = null!;

        public int? ProductId { get; set; }
        public Product? Product { get; set; }

    }
}
