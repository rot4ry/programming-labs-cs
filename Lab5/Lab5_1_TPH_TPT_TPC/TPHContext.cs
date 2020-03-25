using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    // Table Per Hierarchy - domyslne zachowanie EF
    public class TPHContext : DbContext
    {
        public DbSet<Computer> Computers { get; set; }
    }
}
