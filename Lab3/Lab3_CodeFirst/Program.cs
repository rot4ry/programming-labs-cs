using System;
using System.Linq;

namespace Lab3
{
    //Entity Framework
    //podejscia:
    //Code first            <--
    //Data base first
    public class Program
    {
        static void Main(string[] args)
        {
            Kontekst db = new Kontekst();

            db.Database.EnsureCreated();    //zapewnia utworzenie nowej tabeli

            db.Zajecia_set.Add(
                new Zajecia() {
                
                    Id = 1, Nazwa = "P4", GodzinaRozpoczecia = new DateTime(2020, 1, 1, 13, 30, 0) 
                }
            );
            
            db.SaveChanges();

            var zajecia = db.Zajecia_set;
            foreach(var item in zajecia)
            {
                Console.WriteLine($"{item.Id}, {item.Nazwa}, {item.GodzinaRozpoczecia}");
            }

            var zajeciaDoZmiany = db.Zajecia_set.First(x => x.Nazwa.StartsWith("P"));
            zajeciaDoZmiany.Nazwa = "AM2";
            db.Update(zajeciaDoZmiany);
            db.SaveChanges();
        }
    }
}
