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
            string connectionString = @"Data Source=DESKTOP-GSQML5J\MYSERVER;
                                        Initial Catalog = Northwind;
                                        Integrated Security=True;
                                        Connect Timeout=30;
                                        Encrypt=False;
                                        TrustServerCertificate=False;
                                        ApplicationIntent=ReadWrite;
                                        MultiSubnetFailover=False";
            using var connection = new SqlConnection(connectionString);

            
            db.Select(connection);
            db.Insert(connection, new Region { RegionId = 115, RegionDescription = "asd"});
            db.Select(connection);
            db.Insert(connection, 13, "overload");
            db.Select(connection);
            db.Update(connection, 13, "updated");
            db.Select(connection);
            db.Delete(connection, 13);
        }
    }
}
