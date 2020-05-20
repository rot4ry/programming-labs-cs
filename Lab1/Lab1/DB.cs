using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Lab1
{
    public class DB
    {
        public void Select(SqlConnection connection)
        {
            var query = "SELECT * FROM Region";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{ reader["RegionID"] } { reader["RegionDescription"]}");
            }
            reader.Close();

            Console.WriteLine();
        }

        public void Insert(SqlConnection connection, int id, string description)
        {
            var query = "INSERT INTO Region(RegionID, RegionDescription) " +
                        "VALUES (@RegionID, @RegionDescription)";

            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("RegionID", id);
            command.Parameters.AddWithValue("RegionDescription", description);

            var affected = command.ExecuteNonQuery();
            Console.WriteLine($"{affected} rows affected[INSERT]");
        }

        public void Update(SqlConnection connection, int id, string updatedDescription)
        {
            string query =  "UPDATE Region " +
                            "SET RegionDescription=@RegionDescription " +
                            "WHERE RegionID=@RegionID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("RegionID", id);
            command.Parameters.AddWithValue("RegionDescription", updatedDescription);

            var affected = command.ExecuteNonQuery();
            Console.WriteLine($"{affected} rows affected [UPDATE]");
        }   

        public void Delete(SqlConnection connection, int id)
        {
            string query = "DELETE FROM Region WHERE RegionID=@RegionID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("RegionID", id);

            var affected = command.ExecuteNonQuery();
            Console.WriteLine($"{affected} rows affected [DELETE]");
        }
    }
}

