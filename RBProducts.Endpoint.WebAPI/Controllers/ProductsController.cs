using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using RBProducts.Application.Services.Products.Commands.Delete;
using RBProducts.Application.Services.Products.Commands.Insert;
using RBProducts.Application.Services.Products.Commands.Update;
using RBProducts.Application.Services.Products.Queries.GetProducts;
using RBProducts.Endpoint.WebAPI.Models.Products;
using RBProducts.Endpoint.WebAPI.Services.Security.Login;

namespace RBProducts.Endpoint.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGetProductsService _getProductsService;
        private readonly IInsertProductService _insertProductService;
        private readonly IUpdateProductService _updateProductService;
        private readonly IDeleteProductService _deleteProductService;
        private readonly IMapper _mapper;
        public ProductsController(IGetProductsService getProductsService , 
            IInsertProductService insertProductService,
            IUpdateProductService updateProductService,
            IDeleteProductService deleteProductService , IMapper mapper)
        {
            _getProductsService = getProductsService;
            _insertProductService = insertProductService;
            _updateProductService = updateProductService;
            _deleteProductService = deleteProductService;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Products([FromQuery, FromForm, FromBody] RequestGetProductsModel model)
        {
            return Ok(_getProductsService.Execute(_mapper.Map<RequestGetProductsDto>(model)));
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Product(RequestInsertModel model)
        {
            var uid = User.FindFirst(LoginServiceClaimType.Userid);
            model.RequestUserID = uid.Value;
            return Ok(_insertProductService.Execute(_mapper.Map<RequestInsertProductDto>(model)));
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Product(RequestUpdateModel model)
        {
            var uid = User.FindFirst(LoginServiceClaimType.Userid);
            model.RequestUserID = uid.Value;
            return Ok(_updateProductService.Execute(_mapper.Map<RequestUpdateProductDto>(model)));
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Product(RequestDeleteModel model)
        {
            var uid = User.FindFirst(LoginServiceClaimType.Userid);
            model.RequestUserID = uid.Value;
            return Ok(_deleteProductService.Execute(_mapper.Map<RequestDeleteProductDto>(model)));
        }
    }
}
