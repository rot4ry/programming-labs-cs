using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Lab1
{
    
    public class Program
    {
        //CRUD
        //Create, Read, Update, Delete

        public static void Main(string[] args)
        {
            var db = new DB();
            string connectionString = @"connectionString";
            using SqlConnection connection = new SqlConnection(connectionString);
            
            connection.Open();

            db.Select(connection);
            db.Insert(connection, 15, "Bielsko");
            db.Update(connection, 15, "Bielsko-Biała");
            db.Delete(connection, 15);
            
            connection.Close();
        }
    }
}
