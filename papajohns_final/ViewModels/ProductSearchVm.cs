using papajohns_final.Models;

namespace papajohns_final.ViewModels
{
    public class ProductSearchVm
    {
        public string? Name { get; set; }  
        public string? CategoryId { get; set; }

        public List<Category?> Categories { get; set; }
    }
}
