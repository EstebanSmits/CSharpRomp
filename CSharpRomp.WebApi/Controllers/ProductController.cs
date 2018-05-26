using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpRomp.EF.Database;
using CSharpRomp.Entities;
using CSharpRomp.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSharpRomp.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]

    public class ProductController : Controller
    {
        
        private IDapperRepository _IDapperRepository;
        private ModelContext _context;

        public ProductController([FromServices] IDapperRepository myDR, [FromServices]  ModelContext context)
        {
            _context = context;
            _IDapperRepository = myDR;
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProduct()
        {
            return await _IDapperRepository.GetRecords<Product>("Select * from SalesLT.Product");
        }

        /// <summary>
        /// GetProducts
        /// </summary>
        /// <param name="take"></param>
        
        /// <returns></returns>
        [HttpGet("{take}")]
        public  IQueryable<Product> GetProducts(int take)
        {
            
            var result = _context.Products.Take(take);
            return result;

        }


    }
}