namespace papajohns_final.Models
{
    public class Restaurants:BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;

        public string WorkTime { get; set; } = null!;
        
    }
}
