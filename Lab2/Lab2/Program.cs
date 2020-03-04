using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;

//Dapper
//podłączyć sql server object explorer
//dapper-tutorial.net/step-by-step-tutorial
namespace Lab2
{

    public class Region {
        //model
        //pole w klasie nazywa się jak kolumna w bazie
        public int RegionId { get;set;}
        public string RegionDescription { get; set; }
    }

    public class DB
    {
        public void Select(IDbConnection connection)
        {
            var regions = connection.Query<Region>("SELECT * FROM Region");

            foreach (var item in regions)
            {
                Console.WriteLine($"{item.RegionId}, {item.RegionDescription}");
            }
        }

        public void Insert(IDbConnection connecton, Region region)
        {
            connecton.Execute("INSERT INTO Region(RegionId, RegionDescription)"
                + "VALUES(@id, @desc)", new { id = region.RegionId, desc = region.RegionDescription });
        }

        public void Insert(IDbConnection connecton, int id, string description)
        {
            connecton.Execute("INSERT INTO Region(RegionId, RegionDescription)"
                + "VALUES(@id, @desc)", new { id = id, desc = description });
        }

        //public void Delete(
    }

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
