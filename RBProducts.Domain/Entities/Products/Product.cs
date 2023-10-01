using RBProducts.Domain.Entities.ApplicationUser;

namespace RBProducts.Domain.Entities.Products
{
    public class Product : BaseEntity<long>
    {
        public string Name { get; set; }
        public DateTime ProduceDate { get; set; }
        public string ManufacturePhone { get; set; }
        public string ManufactureEmail { get; set; }
        public ProductIsAvailable IsAvailable { get; set; }

        public string AppUserId { set; get; }
        public AppUser AppUser { set; get; }
    }
}
