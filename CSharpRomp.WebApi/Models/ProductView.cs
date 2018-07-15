using System;
using System.Collections.Generic;
using System.Linq;
using CSharpRomp.Entities;
using System.Threading.Tasks;

namespace CSharpRomp.WebApi.Models
{
    public class ProductView:Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
}
