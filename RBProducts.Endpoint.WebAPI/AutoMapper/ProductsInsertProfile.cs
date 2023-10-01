using AutoMapper;
using RBProducts.Application.Services.Products.Commands.Insert;
using RBProducts.Endpoint.WebAPI.Models.Products;

namespace RBProducts.Endpoint.WebAPI.AutoMapper
{
    public class ProductsInsertProfile : Profile
    {
        public ProductsInsertProfile()
        {
            CreateMap<RequestInsertModel, RequestInsertProductDto>().ReverseMap();
        }
    }
}
