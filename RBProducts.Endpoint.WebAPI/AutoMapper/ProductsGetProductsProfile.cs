using AutoMapper;
using RBProducts.Application.Services.Products.Queries.GetProducts;
using RBProducts.Domain.Entities.Products;
using RBProducts.Endpoint.WebAPI.Models.Products;

namespace RBProducts.Endpoint.WebAPI.AutoMapper
{
    public class ProductsGetProductsProfile : Profile
    {
        public ProductsGetProductsProfile()
        {
            CreateMap<RequestGetProductsDto, RequestGetProductsModel>().ReverseMap();
            CreateMap<GetProductsDto,Product>()
                .ForMember(d => d.AppUserId, m => m.MapFrom(src => src.UserID))
                .ReverseMap();
        }
    }
}
