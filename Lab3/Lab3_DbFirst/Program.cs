using System;

namespace Lab3_DbFirst
{
    public class Program
    {
        static void Main(string[] args)
        {
            var nwctx = new NorthwindContext();
            
            foreach(var item in nwctx.Customers)
            {
                Console.WriteLine(order.Cuistomer.CompanyName);
            }
        }
    }
}
