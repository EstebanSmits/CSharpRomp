using System.ComponentModel.DataAnnotations.Schema;
using CSharpRomp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace CSharpRomp.EF.Database
{


    public class ModelContext :DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CustomerAddress>()
                .HasKey(c => new { c.CustomerId, c.AddressId});
            modelBuilder.ApplyConfiguration(new CustomerAddressConfiguration() );
            modelBuilder.Entity<SalesOrderHeader>().HasKey(i => i.SalesOrderId);
            modelBuilder.Entity<ProductModelProductDescription>().HasKey(i => i.ProductDescriptionId);
            modelBuilder.Entity<BuildVersion>().HasKey(i => i.SystemInformationId);
        }
    

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<BuildVersion> BuildVersion { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddress { get; set; }
        public virtual DbSet<ErrorLog> ErrorLog { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductDescription> ProductDescription { get; set; }
        public virtual DbSet<ProductModel> ProductModel { get; set; }
        public virtual DbSet<ProductModelProductDescription> ProductModelProductDescription { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetail { get; set; }
        public virtual DbSet<SalesOrderHeader> SalesOrderHeader { get; set; }

 
    }
}

public class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
{

    public void Configure(EntityTypeBuilder<CustomerAddress> builder)
    {
        // The Key
        // The description of the HasKey Method says

        builder.HasKey(k => new {k.AddressId, k.CustomerId}); // The Key

        // Maybe the key properties are not sequenced and you want to override the conventions
        builder.Property(p => p.AddressId).ValueGeneratedOnAdd().IsRequired();
        builder.Property(p => p.CustomerId).ValueGeneratedOnAdd().IsRequired();
    }

}
