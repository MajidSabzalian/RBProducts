using AutoMapper;
using RBProducts.Application.Services.Products.Commands.Delete;
using RBProducts.Endpoint.WebAPI.Models.Products;

namespace RBProducts.Endpoint.WebAPI.AutoMapper
{
    public class ProductsDeleteProfile : Profile
    {
        public ProductsDeleteProfile()
        {
            CreateMap<RequestDeleteModel, RequestDeleteProductDto>().ReverseMap();
        }
    }
}
