using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Lab1
{
    public class DB
    {
        public void Select(SqlConnection connection)
        {
            var query = "SELECT * FROM Customers";
            var command = new SqlCommand(query, connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                //  Console.WriteLine(reader.["CompanyName"]);
            }
        }

        public void Insert(SqlConnection connection, int id, string description)
        {
            var query = "INSERT INTO region(regionId, regionDescription)"
                + "VALUES (@id, '@description')";
            
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@description", description);

            var affected = command.ExecuteNonQuery();
            Console.WriteLine($"{affected} rows affected");
        }

        public void Update(SqlConnection connection, int id, string description)
        {
            var query = "UPDATE region(regionId, regionDescription)"
                + $"SET regionDescription = {description}"
                + $"WHERE @id = {id}";

            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@description", description);

            var affected = command.ExecuteNonQuery();
            Console.WriteLine($"{affected} rows affected");
        }

        public void Delete(SqlConnection connection, int id)
        {
            var query = "DELETE FROM region(regionId, regionDescription)"
                    + $"WHERE @id = {id}";

            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("id", id);

            var affected = command.ExecuteNonQuery();
            Console.WriteLine($"{affected} rows affected");
        }
    }

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
