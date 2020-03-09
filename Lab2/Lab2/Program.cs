using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;

//Dapper
//dapper-tutorial.net/step-by-step-tutorial
namespace Lab2
{
    //dynamic - "Likwiduje" silne typowanie, pozwala nie podawac dokladnego typu zmiennej
    //IDbConnection connection = new SqlConnection();
    //var regions = connection.Query("SELECT * FROM Region");
    
    class Program
    {
        static void Main(string[] args) {

            var db = new DB();
            string connectionString = @"abc";
            var connection = new SqlConnection(connectionString);
            db.Select(connection);
            db.Insert(connection, new Region { RegionId = 555, RegionDescription = "asd"});
            db.Insert(connection, 10, "overload");
        }
    }
}
