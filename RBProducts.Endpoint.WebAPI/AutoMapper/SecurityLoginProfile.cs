using AutoMapper;
using RBProducts.Endpoint.WebAPI.Models.Security;
using RBProducts.Endpoint.WebAPI.Services.Security.Login;

namespace RBProducts.Endpoint.WebAPI.AutoMapper
{
    public class SecurityLoginProfile : Profile
    {
        public SecurityLoginProfile()
        {
            CreateMap<RequestLoginModel, RequestLoginDto>().ReverseMap();
        }
    }
}
