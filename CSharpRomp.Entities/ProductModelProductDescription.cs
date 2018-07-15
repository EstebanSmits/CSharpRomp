using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSharpRomp.Entities
{
    public partial class ProductModelProductDescription
    {
        public int ProductModelId { get; set; }
        [Key]
        public int ProductDescriptionId { get; set; }
        public string Culture { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ProductDescription ProductDescription { get; set; }
        public ProductModel ProductModel { get; set; }
    }
}
