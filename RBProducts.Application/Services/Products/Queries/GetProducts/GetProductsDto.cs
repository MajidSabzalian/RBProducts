using RBProducts.Domain.Entities.Products;

namespace RBProducts.Application.Services.Products.Queries.GetProducts
{
    public class GetProductsDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = "";
        public DateTime ProduceDate { get; set; }
        public string ManufacturePhone { get; set; } = "";
        public string ManufactureEmail { get; set; } = "";
        public ProductIsAvailable IsAvailable { get; set; }
        public string UserID { get; set; } = "";
    }
}
