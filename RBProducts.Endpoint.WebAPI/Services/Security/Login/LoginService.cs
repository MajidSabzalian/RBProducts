using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using RBProducts.Application.Contexts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RBProducts.Endpoint.WebAPI.Services.Security.Login
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IDataBaseContext _context;
        public LoginService(IDataBaseContext context, UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        public async Task<ResultLoginDto> ExecuteAsync(RequestLoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(type : LoginServiceClaimType.Username, user.UserName),
                    new Claim(type : LoginServiceClaimType.Userid, user.Id),
                    new Claim(type : LoginServiceClaimType.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(type: ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return new ResultLoginDto()
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                };
            }
            return new ResultLoginDto()
            {
                token = "",
                expiration = DateTime.Now
            };
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                //issuer: _configuration["JWT:ValidIssuer"],
                //audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
