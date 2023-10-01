using AutoMapper;
using RBProducts.Application.Services.Products.Commands.Update;
using RBProducts.Endpoint.WebAPI.Models.Products;

namespace RBProducts.Endpoint.WebAPI.AutoMapper
{
    public class ProductsUpdateProfile : Profile
    {
        public ProductsUpdateProfile()
        {
            CreateMap<RequestUpdateModel, RequestUpdateProductDto>().ReverseMap();
        }
    }
}
