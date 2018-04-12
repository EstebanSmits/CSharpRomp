using CSharpRomp.Entities;
using CSharpRomp.Repository.Interface;
using CSharpRomp.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
            this.tokenConfig = tokenConfig;
            this.ClaimConfig = claimConfig;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RequestTokenAsync([FromBody] TokenRequest request, [FromServices] IDapperRepository myDR)
        {
            var myLogin = await myDR.GetRecord<AppLogin>("select * from AppLogin", new AppLogin { username = request.Username, password = request.Password });
            if (myLogin.id != null)
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