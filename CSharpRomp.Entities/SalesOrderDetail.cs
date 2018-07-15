using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSharpRomp.Entities
{
    public partial class SalesOrderDetail
    {
        public int SalesOrderId { get; set; }
        [Key]
        public int SalesOrderDetailId { get; set; }
        public short OrderQty { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
        public decimal LineTotal { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Product Product { get; set; }
        public SalesOrderHeader SalesOrder { get; set; }
    }
}
