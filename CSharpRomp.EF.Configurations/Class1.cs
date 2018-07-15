using CSharpRomp.Entities;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpRomp.EF.Configurations
{

    class CustomerAddressConfiguration : EntityTypeConfiguration<CustomerAddress>
    {

        public CustomerAddressConfiguration()
        {
            // The Key
            // The description of the HasKey Method says

            this.HasKey(k => new { k.AddressId, k.CustomerId }); // The Key

            // Maybe the key properties are not sequenced and you want to override the conventions
            this.Property(p => p.AddressId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(p => p.CustomerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }