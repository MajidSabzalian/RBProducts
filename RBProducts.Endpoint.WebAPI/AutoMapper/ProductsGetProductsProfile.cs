using AutoMapper;
using RBProducts.Application.Services.Products.Queries.GetProducts;
using RBProducts.Endpoint.WebAPI.Models.Products;

namespace RBProducts.Endpoint.WebAPI.AutoMapper
{
    public class ProductsGetProductsProfile : Profile
    {
        public ProductsGetProductsProfile()
        {
            CreateMap<RequestGetProductsDto, RequestGetProductsModel>().ReverseMap();
        }
    }
}
