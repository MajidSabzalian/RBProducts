using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using RBProducts.Endpoint.WebAPI.Services.Security.Login;
using Microsoft.AspNetCore.Authorization;
using RBProducts.Endpoint.WebAPI.Models.Security;
using AutoMapper;
using RBProducts.Endpoint.WebAPI.Utils;

namespace RBProducts.Endpoint.WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ILoginService _checkLoginService;
        private readonly IMapper _mapper;
        public SecurityController(ILoginService checkLoginService , IMapper mapper)
        {
            _checkLoginService = checkLoginService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] RequestLoginModel model)
        {
            if (!ModelState.IsValid) { return Ok(ModelState.GetErrorResult()); }
            return Ok(await _checkLoginService.ExecuteAsync(_mapper.Map<RequestLoginDto>(model)));
        }
    }
}
