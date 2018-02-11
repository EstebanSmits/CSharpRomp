using System;
using System.Collections.Generic;

namespace CSharpRomp.Models
{
    public partial class Colors
    {
        public Colors()
        {
            StockItems = new HashSet<StockItems>();
        }

        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public People LastEditedByNavigation { get; set; }
        public ICollection<StockItems> StockItems { get; set; }
    }
}
