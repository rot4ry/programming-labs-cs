using System;
using System.Collections.Generic;
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


        public void Delete(IDbConnection connection, int id)
        {
            connection.Execute("DELETE FROM Region(RegionId, RegionDescription")
                + $"WHERE RegionId = {id}", new { id = id });
        }
    }
}
