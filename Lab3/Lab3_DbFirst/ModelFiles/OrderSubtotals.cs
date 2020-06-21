using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3_DbFirst.ModelFiles
{
    public partial class OrderSubtotals
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
