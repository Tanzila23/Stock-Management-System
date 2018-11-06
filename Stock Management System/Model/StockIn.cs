using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Management_System.Model
{
    class StockIn
    {
        public string ComapanyName { get; set; }
        public string CatagoryName { get; set; }
        public string Item { get; set; }
        public string ReorderLavel { get; set; }
        public string AvailableQuantity { get; set; }
        public string StockInQuantity { get; set; }
    }
}
