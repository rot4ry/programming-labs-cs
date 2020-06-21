using System;
using System.Data.Entity;
using System.Linq;

namespace Lab3_DbFirst
{
    public class Program
    {
        static void Main(string[] args)
        {
            NorthwindContext nwContext = new NorthwindContext();

            var join = nwContext.Categories.Include(x => x.Products);
            var query = join.Take(5);

            foreach (var item in query)
            {
                Console.WriteLine($"{item.CategoryName} / {item.Description}");
            }
        }
    }
}
