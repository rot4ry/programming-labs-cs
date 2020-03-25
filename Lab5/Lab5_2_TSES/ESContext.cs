using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_B_TSES
{
    public class ESContext : DbContext
    {
        public DbSet<ESComputer> Computers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ESComputer>().Map(map =>
            {
                map.Properties(prop => new
                {
                    prop.Description,
                    prop.CoolingType
                });
                map.ToTable("PolaTekstowe");
            });

            modelBuilder.Entity<ESComputer>().Map(map =>
            {
                map.Properties(prop => new
                {
                    prop.Price
                });
                map.ToTable("PolaLiczbowe");
            });

        }
    }
}
