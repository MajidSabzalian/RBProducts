using RBProducts.Domain.Entities.Products;

namespace RBProducts.Endpoint.WebAPI.Models.Products
{
    public class RequestUpdateModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime ProduceDate { get; set; }
        public string ManufacturePhone { get; set; }
        public string ManufactureEmail { get; set; }
        public ProductIsAvailable IsAvailable { get; set; }

        public string RequestUserID { set; get; } = "";
    }
}
