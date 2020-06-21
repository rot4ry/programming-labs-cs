using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3_DbFirst.ModelFiles
{
    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
