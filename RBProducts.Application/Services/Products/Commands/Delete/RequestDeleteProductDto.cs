using RBProducts.Domain.Entities.Products;

namespace RBProducts.Application.Services.Products.Commands.Delete
{
    public class RequestDeleteProductDto
    {
        public long Id { get; set; }
        public string RequestUserID { set; get; } = "";
    }
}