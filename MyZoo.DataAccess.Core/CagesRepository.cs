using System.Collections.Generic;
using System.Data.SqlClient;
using MyZoo.Common.Interfaces;
using MyZoo.Common.ZooItems.BaseClasses;


namespace MyZoo.DataAccess.Core
{
    public class CagesRepository : Repository, IZooItemsRepository<IZooItems<Cage>>
    {
        private IZooItems<Cage> _cage;

        public void Insert(IZooItems<Cage> cages)
        {
            const string sql =
               "INSERT INTO Cages(specie, kind) Values(@Specie, @Kind)";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                     
                    command.Parameters.AddWithValue("@Specie", cages.Specie);
                    command.Parameters.AddWithValue("@Kind", cages.Kind);

                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<IZooItems<Cage>> GetAllItems()
        {
            const string sql = "SELECT * FROM Cages";

            var cagesList = new List<IZooItems<Cage>>();

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
                                 reader["specie"].ToString(),
                                 reader["kind"].ToString())
                             );
                     }
                 }
               }

           }
           return cagesList;
        }

        public IZooItems<Cage> GetLastCreatedItem()
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
                                reader["specie"].ToString(),
                                reader["kind"].ToString()
                                );
                        }
                    }
                }
           }

            return _cage;
       }
   }
}
