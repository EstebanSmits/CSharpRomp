using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpRomp.Entities
{
    public partial class Address
    {
        public Address()
        {
            CustomerAddress = new HashSet<CustomerAddress>();
            SalesOrderHeaderBillToAddress = new HashSet<SalesOrderHeader>();
            SalesOrderHeaderShipToAddress = new HashSet<SalesOrderHeader>();
        }
        [Key]
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryRegion { get; set; }
        public string PostalCode { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        [NotMapped]
        public ICollection<CustomerAddress> CustomerAddress { get; set; }
        [NotMapped]
        public ICollection<SalesOrderHeader> SalesOrderHeaderBillToAddress { get; set; }
        [NotMapped]
        public ICollection<SalesOrderHeader> SalesOrderHeaderShipToAddress { get; set; }
    }
}
