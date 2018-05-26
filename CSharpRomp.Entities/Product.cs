using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace CSharpRomp.Entities
{

    [Table("Product", Schema = "SalesLT")]
    public class Product
    {
        

        public Product() { }


        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public object StandardCost { get; set; }
        public object ListPrice { get; set; }
        public string Size { get; set; }
        public decimal? Weight { get; set; }
        public int ProductCategoryID { get; set; }
        public int ProductModelID { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public byte[] ThumbNailPhoto { get; set; }
        public string ThumbnailPhotoFileName { get; set; }
        public object rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }

}
