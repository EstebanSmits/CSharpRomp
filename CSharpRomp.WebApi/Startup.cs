using CSharpRomp.WebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using CSharpRomp.Repository;
using CSharpRomp.Repository.Interface;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using CSharpRomp.EF.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.PlatformAbstractions;

namespace CSharpRomp.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
            Configuration.GetConnectionString("daxmaxDB");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Bind some application level Configurations
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));
            services.Configure<TokenSettings>(Configuration.GetSection("TokenSettings"));
            services.Configure<ClaimSettings>(Configuration.GetSection("ClaimSettings"));
            

            // Bind Configuration
            services.AddSingleton(Configuration);
            
            // ... well we need some of those configs right here, lets created an intermediate service provider to retrieve those Options
            var sp = services.BuildServiceProvider();
            // Resolve the services from the service provider
            var tokenOptions = sp.GetService<IOptions<TokenSettings>>();
            var appOptions= sp.GetService<IOptions<ApplicationSettings>>();
            services.AddDbContext<ModelContext>(options =>
                options.UseSqlServer((Configuration.GetConnectionString("daxmaxDB"))));
            services.AddTransient<IDapperRepository, BaseRepository>(serviceProvider => { return new BaseRepository(Configuration.GetConnectionString("daxmaxDB")); } );
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme =  JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer("JwtBearer", jwtBearerOptions =>
            {
                jwtBearerOptions.SaveToken = true;
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    //TODO: Set  actual Signing Key
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.Value.SecretKey)),
                    ValidateIssuer = true,
                    ValidIssuer = tokenOptions.Value.Issuer,
                    ValidateAudience = true,
                    ValidAudience = tokenOptions.Value.Audience,
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });

            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
        
                c.SwaggerDoc("v1", new Info { Title = appOptions.Value.ApplicationName});
                c.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "CSharpRomp.WebApi.xml"));
            });

        }

        private void CreateClaims()
        {
            var claimConfig = (ClaimSettings)Configuration.GetSection("ClaimSettings");
            var tokenConfig = (TokenSettings)Configuration.GetSection("TokenSettings");

            //TODO: Set real claim values & password
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asdasd"));
            // using a combination of standard claim type and JWTRegistered ClaimName types
            var claims = new Claim[] { new Claim(ClaimTypes.Name, "daxmax"), new Claim(JwtRegisteredClaimNames.Email, "daxmax@gmail.com") };
            var token = new JwtSecurityToken(
                issuer: tokenConfig.Issuer,
                audience: tokenConfig.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(claimConfig.ClaimExpiration),
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptions<ApplicationSettings> config, IDistributedCache Cache)
        {
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", config.Value.ApplicationName);
            });
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            
            
        }
    }
}