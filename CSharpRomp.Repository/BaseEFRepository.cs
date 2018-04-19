using CSharpRomp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSharpRomp.Repository
{
    class BaseEFRepository :DbContext
    {
        public BaseEFRepository()
        {

        }
        public DbSet<Customer> Customers;
        public DbSet<Product> Products;

    }
}
