using CSharpRomp.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using DbContext = System.Data.Entity.DbContext;

namespace CSharpRomp.EF.NET.Database
{
  
    public partial class ModelContext : DbContext
    {
        public ModelContext(string connString)
            : base(connString)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SalesLT");
            modelBuilder.Configurations.Add(new CustomerAddressConfiguration());
            modelBuilder.Entity<SalesOrderHeader>().HasKey(i => i.SalesOrderId);
            modelBuilder.Entity<ProductModelProductDescription>().HasKey(i => i.ProductDescriptionId);
            modelBuilder.Entity<BuildVersion>().HasKey(i => i.SystemInformationId);
        }

        public virtual System.Data.Entity.DbSet<Address> Address { get; set; }
        public virtual System.Data.Entity.DbSet<BuildVersion> BuildVersion { get; set; }
        public virtual System.Data.Entity.DbSet<Customer> Customer { get; set; }
        public virtual System.Data.Entity.DbSet<CustomerAddress> CustomerAddress { get; set; }
        public virtual System.Data.Entity.DbSet<ErrorLog> ErrorLog { get; set; }
        public virtual System.Data.Entity.DbSet<Product> Product { get; set; }
        public virtual System.Data.Entity.DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual System.Data.Entity.DbSet<ProductDescription> ProductDescription { get; set; }
        public virtual System.Data.Entity.DbSet<ProductModel> ProductModel { get; set; }
        public virtual System.Data.Entity.DbSet<ProductModelProductDescription> ProductModelProductDescription { get; set; }
        public virtual System.Data.Entity.DbSet<SalesOrderDetail> SalesOrderDetail { get; set; }
        public virtual System.Data.Entity.DbSet<SalesOrderHeader> SalesOrderHeader { get; set; }

  
    }
}

public class CustomerAddressConfiguration : EntityTypeConfiguration<CustomerAddress>
{

    public CustomerAddressConfiguration()
    {
        this.HasKey(k => new {k.AddressId, k.CustomerId}); // The Key
        this.Property(p => p.AddressId)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        this.Property(p => p.CustomerId)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
    }
}