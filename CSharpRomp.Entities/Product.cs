using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace CSharpRomp.Entities
{

    [Table("Product", Schema = "SalesLT")]
    public class Product
    {
        #region Constructors  
        public Product() { }
        #endregion
        #region Private Fields  
        private int _ProductID;
        private string _Name;
        private string _ProductNumber;
        private string _Color;
        private object _StandardCost;
        private object _ListPrice;
        private string _Size;
        private object _Weight;
        private int _ProductCategoryID;
        private int _ProductModelID;
        private DateTime _SellStartDate;
        private DateTime _SellEndDate;
        private DateTime _DiscontinuedDate;
        private byte[] _ThumbNailPhoto;
        private string _ThumbnailPhotoFileName;
        private object _rowguid;
        private DateTime _ModifiedDate;
        #endregion
        #region Public Properties  
        public int ProductID { get { return _ProductID; } set { _ProductID = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string ProductNumber { get { return _ProductNumber; } set { _ProductNumber = value; } }
        public string Color { get { return _Color; } set { _Color = value; } }
        public object StandardCost { get { return _StandardCost; } set { _StandardCost = value; } }
        public object ListPrice { get { return _ListPrice; } set { _ListPrice = value; } }
        public string Size { get { return _Size; } set { _Size = value; } }
        public object Weight { get { return _Weight; } set { _Weight = value; } }
        public int ProductCategoryID { get { return _ProductCategoryID; } set { _ProductCategoryID = value; } }
        public int ProductModelID { get { return _ProductModelID; } set { _ProductModelID = value; } }
        public DateTime SellStartDate { get { return _SellStartDate; } set { _SellStartDate = value; } }
        public DateTime SellEndDate { get { return _SellEndDate; } set { _SellEndDate = value; } }
        public DateTime DiscontinuedDate { get { return _DiscontinuedDate; } set { _DiscontinuedDate = value; } }
        public byte[] ThumbNailPhoto { get { return _ThumbNailPhoto; } set { _ThumbNailPhoto = value; } }
        public string ThumbnailPhotoFileName { get { return _ThumbnailPhotoFileName; } set { _ThumbnailPhotoFileName = value; } }
        public object rowguid { get { return _rowguid; } set { _rowguid = value; } }
        public DateTime ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }
        #endregion  }

    }
}