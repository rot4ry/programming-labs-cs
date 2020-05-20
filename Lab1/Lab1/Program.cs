using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Lab1
{
        //CRUD
        //Create, Read, Update, Delete
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new DB();
            
            string connectionString = @"Data Source=DESKTOP-GSQML5J\MYSERVER;
                                        Initial Catalog = Northwind;
                                        Integrated Security=True;
                                        Connect Timeout=30;Encrypt=False;
                                        TrustServerCertificate=False;
                                        ApplicationIntent=ReadWrite;
                                        MultiSubnetFailover=False";
            using SqlConnection connection = new SqlConnection(connectionString);
            
            connection.Open();

            db.Select(connection);
            Console.ReadLine();
            db.Insert(connection, 10, "Bielsko");
            Console.ReadLine();
            db.Insert(connection, 15, "Warszawa");
            Console.ReadLine();
            db.Update(connection, 15, "Bielsko-Biała");
            Console.ReadLine(); 
            db.Delete(connection, 10);
            
            connection.Close();
        }
    }
}
