using System.Collections.Generic;
using System.Data.SqlClient;
using MyZoo.Common.ZooItems.BaseClasses;
using MyZoo.Common.ZooItems.Interfaces.Common_Layer_interfaces;


namespace MyZoo.DataAccess.Core
{
    public class CagesRepository : Repository
    {
        private ICages _cage;
        
        public void Insert(ICages cages)
        {
            const string sql =
               "INSERT INTO Cages(type, heght, weght, length) Values(@Type, @Heght, @Weght, @Length)";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Type", cages.Type);
                    command.Parameters.AddWithValue("@Heght", cages.Heght);
                    command.Parameters.AddWithValue("@Weght", cages.Weght);
                    command.Parameters.AddWithValue("@Length", cages.Length);

                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<ICages> GetAll()
        {
            const string sql = "SELECT * FROM Cages";

          var cagesList = new List<ICages>();

            using (var connection = new SqlConnection(ConnectionString))
           {
               connection.Open();

                using (var command = new SqlCommand(sql, connection))
               {
                 using (SqlDataReader reader = command.ExecuteReader())
               {
                     while (reader.Read())
                     {
                         cagesList.Add(
                             new Cage(
                                 reader["type"].ToString(),
                                (int) reader["heght"],
                                (int) reader["weght"],
                                (int) reader["length"])
                                );
                     }
                 }
               }

           }
           return cagesList;
        }

        public ICages GetLastCreatedCage()
       {
           const string getEntities = "SELECT TOP 1 * FROM Cages ORDER BY id DESC";
       
          using (var connection = new SqlConnection(ConnectionString))
          {
               connection.Open();

                using (var command = new SqlCommand(getEntities, connection))
                {
                   using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _cage = new Cage(
                                reader["type"].ToString(),
                                (int) reader["heght"],
                                (int) reader["weght"],
                                (int) reader["length"] );
                        }
                    }
                }
           }

            return _cage;
       }
   }
}
