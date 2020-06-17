using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4_TeamsAndCoaches
{
    public class Context : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<TeamSeason> Seasons { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-GSQML5J\MYSERVER;
                                          Initial Catalog=TeamsAndCoaches;
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
            modelBuilder.Entity<Team>().HasKey("id");

            modelBuilder.Entity<Team>()
                .Property(x => x.id)
                .ValueGeneratedNever()
                .IsRequired();

            //Coach config
            modelBuilder.Entity<Coach>().HasKey("coach_id");

            modelBuilder.Entity<Coach>()
                .Property(x => x.coach_id)
                .UseIdentityColumn();

            modelBuilder.Entity<Coach>()
                .Property(x => x.first_name);

            modelBuilder.Entity<Coach>()
                .Property(x => x.last_name);


            //TeamSeason config
            modelBuilder.Entity<TeamSeason>().HasKey("season_id", "coach_id");

            modelBuilder.Entity<TeamSeason>()
                .Property(x => x.season_id)
                .UseIdentityColumn();

        }
    }
}
