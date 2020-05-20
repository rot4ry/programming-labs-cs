using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Lab2
{
    public class DB
    {
        public void Select(IDbConnection connection)
        {
            var regions = connection.Query<Region>("SELECT * FROM Region");

            foreach (var item in regions)
            {
                Console.WriteLine($"{item.RegionId}, {item.RegionDescription}");
            }
            Console.WriteLine();
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

        public void Update(IDbConnection connection, int id, string description)
        {
            connection.Execute("UPDATE Region " +
                                "SET RegionDescription=@RegionDescription " +
                                "WHERE RegionId=@RegionId",
                                new { RegionId = id, RegionDescription = description });
        }

        public void Delete(IDbConnection connection, int id)
        {
            connection.Execute("DELETE FROM Region WHERE RegionId=@RegionId"
                                , new { RegionId = id });

        }
    } 
}
