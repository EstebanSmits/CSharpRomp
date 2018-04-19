using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSharpRomp.Entities
{
    [Table("Customer", Schema = "SalesLT")]

    public class Customer
    {
        #region Constructors  
        public Customer() { }
        #endregion
        #region Private Fields  
        private int _CustomerID;
        private bool _NameStyle;
        private string _Title;
        private string _FirstName;
        private string _MiddleName;
        private string _LastName;
        private string _Suffix;
        private string _CompanyName;
        private string _SalesPerson;
        private string _EmailAddress;
        private string _Phone;
        private string _PasswordHash;
        private string _PasswordSalt;
        private object _rowguid;
        private DateTime _ModifiedDate;
        #endregion
        #region Public Properties  
        public int CustomerID { get { return _CustomerID; } set { _CustomerID = value; } }
        public bool NameStyle { get { return _NameStyle; } set { _NameStyle = value; } }
        public string Title { get { return _Title; } set { _Title = value; } }
        public string FirstName { get { return _FirstName; } set { _FirstName = value; } }
        public string MiddleName { get { return _MiddleName; } set { _MiddleName = value; } }
        public string LastName { get { return _LastName; } set { _LastName = value; } }
        public string Suffix { get { return _Suffix; } set { _Suffix = value; } }
        public string CompanyName { get { return _CompanyName; } set { _CompanyName = value; } }
        public string SalesPerson { get { return _SalesPerson; } set { _SalesPerson = value; } }
        public string EmailAddress { get { return _EmailAddress; } set { _EmailAddress = value; } }
        public string Phone { get { return _Phone; } set { _Phone = value; } }
        public string PasswordHash { get { return _PasswordHash; } set { _PasswordHash = value; } }
        public string PasswordSalt { get { return _PasswordSalt; } set { _PasswordSalt = value; } }
        public object rowguid { get { return _rowguid; } set { _rowguid = value; } }
        public DateTime ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }
        #endregion  }
    }
}
