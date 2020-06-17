using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4_TeamsAndStats
{
    public class Context : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Stat> Stats { get; set; }
        public DbSet<Offense> Offenses { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-GSQML5J\MYSERVER;
                                          Initial Catalog=TeamsAndStats;
                                          Integrated Security=True;
                                          Connect Timeout=30;
                                          Encrypt=False;
                                          TrustServerCertificate=False;
                                          ApplicationIntent=ReadWrite;
                                          MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //F   L   U   E   N   T
            base.OnModelCreating(modelBuilder);

            //Team config
            modelBuilder.Entity<Team>().HasKey("school");

            modelBuilder.Entity<Team>()
                .Property(x => x.id)
                .ValueGeneratedNever()
                .IsRequired();

            //Stat config
            modelBuilder.Entity<Stat>().HasKey("STAT_ID");

            modelBuilder.Entity<Stat>()
                .Property(x => x.STAT_ID)
                .UseIdentityColumn();

            //Offense config
            modelBuilder.Entity<Offense>().HasKey("OFF_ID");

            modelBuilder.Entity<Offense>()
                .Property(x => x.OFF_ID)
                .UseIdentityColumn();
        }
    }
}
