using CSharpRomp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSharpRomp.EF.Database
{


    public class ModelContext :DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
        { }
        
         
        
        public DbSet<Customer> Customers;
        public DbSet<Product> Products;

    }
}
