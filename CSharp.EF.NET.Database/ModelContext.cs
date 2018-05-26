using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpRomp.Entities;

namespace CSharp.EF.NET.Database
{
    public class ModelContext : DbContext
    {
        public ModelContext(string connString)
            : base(connString)
        { }



        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
