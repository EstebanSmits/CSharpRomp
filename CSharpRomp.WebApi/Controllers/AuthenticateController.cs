using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CSharpRomp.Repository.Interface;
using CSharpRomp.WebApi.Models;
using CSharpRomp.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.Extensions.Options;
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
            this.tokenConfig= tokenConfig;
            ClaimConfig = claimConfig;
        }
        [AllowAnonymous]
        [HttpPost]

        public async Task<IActionResult> RequestTokenAsync([FromBody] TokenRequest request, [FromServices] IDapperRepository myDR)
        {
            var myLogin = await myDR.GetRecord<AppLogin>("select * from AppLogin", new AppLogin { username = request.Username, password = request.Password });
            if (myLogin != null && myLogin.id != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Username)
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfig.Value.SecretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: tokenConfig.Value.Issuer,
                    audience: tokenConfig.Value.Audience,
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

