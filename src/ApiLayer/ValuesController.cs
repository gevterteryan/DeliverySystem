using ApiLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> GetToken(TokenRequest request)
        {
            if (string.Equals(request.ClientID, Constants.ClientId, StringComparison.OrdinalIgnoreCase) &&
               string.Equals(request.ClientSecret, Constants.ClientSecret, StringComparison.OrdinalIgnoreCase))
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim("userId", "1")
                };

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.SecurityKey));
                var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken jwt = new JwtSecurityToken(Constants.Issuer, Constants.ClientId, claims, null, DateTime.Now.AddHours(1), signingCred);

                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                return handler.WriteToken(jwt);
            }
            return Unauthorized();
        }
    }
}
