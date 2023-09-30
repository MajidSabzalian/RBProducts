using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using RBProducts.Endpoint.WebAPI.Models;
using RBProducts.Endpoint.WebAPI.Services.Security.Login;
using Microsoft.AspNetCore.Authorization;

namespace RBProducts.Endpoint.WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ICheckLoginService _checkLoginService;
        public SecurityController(ICheckLoginService checkLoginService)
        {
            _checkLoginService = checkLoginService;
        }
        [HttpPost]
        // [Route("login")]
        public async Task<IActionResult> Login([FromBody] SecurityRequestModel model)
        {
            return Ok(await _checkLoginService.ExecuteAsync(new RequestCheckLoginDto() { UserName = model.Username, Password = model.Password }));
        }
    }
}
