using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    //sposób łączenia się z bazą danych 
    //operacje baza-klient
    //konfiguracja przez override metody OnConfiguring
    public class Kontekst : DbContext
    {

        public DbSet<Zajecia> Zajecia_set { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-GSQML5J\MYSERVER;Initial Catalog=CodeFirst;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
   
        }

        //fluent configuration
        //ADNOTACJE OR FLUENT
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Zajecia>()
                .Property(x => x.Nazwa)
                .HasMaxLength(255)
                .IsRequired()
                .HasColumnName("NazwaFluent");
        }
    }
}
