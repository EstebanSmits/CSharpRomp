using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpRomp.Entities
{
    public partial class CustomerAddress
    {
        [Key, Column(Order =0)]
        public int CustomerId { get; set; }
        [Key, Column(Order = 1)]
        public int AddressId { get; set; }
        public string AddressType { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Address Address { get; set; }
        public Customer Customer { get; set; }
    }
}
