using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using RBProducts.Application.Services.Products.Commands.Delete;
using RBProducts.Application.Services.Products.Commands.Insert;
using RBProducts.Application.Services.Products.Commands.Update;
using RBProducts.Application.Services.Products.Queries.GetProducts;
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
        public ProductsController(IGetProductsService getProductsService , 
            IInsertProductService insertProductService,
            IUpdateProductService updateProductService,
            IDeleteProductService deleteProductService)
        {
            _getProductsService = getProductsService;
            _insertProductService = insertProductService;
            _updateProductService = updateProductService;
            _deleteProductService = deleteProductService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Products([FromQuery,FromForm,FromBody]RequestGetProductsDto model)
        {
            return Ok(_getProductsService.Execute(model));
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Product(RequestInsertProductDto model)
        {
            return Ok(_insertProductService.Execute(model));
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Product(RequestUpdateProductDto model)
        {
            var uid = User.FindFirst(CheckLoginServiceClaimType.Userid);
            model.RequestUserID = uid.Value;
            return Ok(_updateProductService.Execute(model));
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Product(RequestDeleteProductDto model)
        {
            return Ok(_deleteProductService.Execute(model));
        }
    }
}
