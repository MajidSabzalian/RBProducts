using RBProducts.Common.Interfaces;
using System.ComponentModel;

namespace RBProducts.Application.Services.Products.Queries.GetProducts
{
    
    public class RequestGetProductsDto : IPaginationRequest
    {
        public string SearchKey { set; get; } = "";
        public int Page { set; get; }
    }
}
