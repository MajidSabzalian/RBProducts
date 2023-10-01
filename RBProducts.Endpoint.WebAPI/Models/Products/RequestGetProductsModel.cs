namespace RBProducts.Endpoint.WebAPI.Models.Products
{
    public class RequestGetProductsModel
    {
        public string? Userid { set; get; }
        public int Page { set; get; } = 1;
    }
}
