using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpRomp.Entities;
using CSharpRomp.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharpRomp.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]

    public class ProductController : Controller
    {
        
        private IDapperRepository _IDapperRepository;
        public ProductController([FromServices] IDapperRepository myDR)
        {
            _IDapperRepository = myDR;
        }
        [HttpGet]
        public async Task<IEnumerable<Product>> getProduct()
        {
            return await _IDapperRepository.GetRecords<Product>("Select * from SalesLT.Product");
        }
     
    }
}