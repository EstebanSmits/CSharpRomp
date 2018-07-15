    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpRomp.EF.Database;
using CSharpRomp.Entities;
using CSharpRomp.Repository.Interface;
using CSharpRomp.WebApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mapster.Adapters;

namespace CSharpRomp.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]

    public class ProductController : Controller
    {
        
        private readonly IDapperRepository _IDapperRepository;
        private readonly ModelContext _context;
        /// <summary>
        /// ProductController
        /// </summary>
        /// <param name="myDr"></param>
        /// <param name="context"></param>
        public ProductController([FromServices] IDapperRepository myDr, [FromServices]  ModelContext context)
        {
            _context = context;
            _IDapperRepository = myDr;
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
        public  IQueryable<ProductView> GetProducts(int take)
        {
            var myProducts = (from P in _context.Product
                join PC in _context.ProductCategory on P.ProductCategoryId equals PC.ProductCategoryId
                join PM in _context.ProductModel on P.ProductModelId equals PM.ProductModelId
                join PMPD in _context.ProductModelProductDescription on P.ProductModelId equals PMPD.ProductModelId
                join PD in _context.ProductDescription on PMPD.ProductDescriptionId equals PD.ProductDescriptionId
                join SOD in _context.SalesOrderDetail on P.ProductId equals SOD.ProductId
                join SOH in _context.SalesOrderHeader on SOD.SalesOrderId equals SOH.SalesOrderId
                join A1 in  _context.Address on SOH.BillToAddressId equals A1.AddressId
                join A2 in _context.Address on SOH.ShipToAddressId equals A2.AddressId
                join C in _context.Customer  on  SOH.CustomerId equals C.CustomerId
                join CA in _context.CustomerAddress on C.CustomerId equals CA.CustomerId
                join A3 in _context.Address on CA.AddressId equals A3.AddressId
                              select P).ProjectToType<ProductView>().ToList();
            return myProducts.Take(take).AsQueryable();
            //var result = _context.Product.Take(take);
            //return result;

        }


    }
}