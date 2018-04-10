using System;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using CSharpRomp.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.Extensions.Options;

namespace CSharpRomp.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Authenticate")]
    public class AuthenticateController : Controller
    {
        private readonly IOptions<ApplicationSettings> config;
        private readonly IOptions<TokenSettings> tokenConfig;
        private readonly IOptions<ClaimSettings> ClaimConfig;
        public AuthenticateController(IOptions<ApplicationSettings> config, IOptions<TokenSettings> tokenConfig, IOptions<ClaimSettings> claimConfig)
        {
            this.config = config;
            this.tokenConfig= tokenConfig;
            this.ClaimConfig = claimConfig;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] TokenRequest request)
        {
            if (request.Username == "Jon" && request.Password == "Again, not for production use, DEMO ONLY!")
            {
                var claims = new[]
                {
                new Claim(ClaimTypes.Name, request.Username)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfig.Value.secretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                
                var token = new JwtSecurityToken(
                    issuer: tokenConfig.Value.issuer,
                    audience: tokenConfig.Value.audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return BadRequest("Could not verify username and password");
        }
    }

}