using System.Collections.Generic;
using System.Data.SqlClient;
using MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces;
using MyZoo.Common.Interfaces;
using MyZoo.Common.ZooItems.BaseClasses;


namespace MyZoo.DataAccess.Core
{
    public class CagesRepository : Repository, IZooItemsRepository<ICage>
    {
        public void Insert(ICage cage)
        {
            const string sql =
                "INSERT INTO Cages(type, height, width, length) Values(@Type, @Height, @Width, @Length)";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Type", cage.Type);
                    command.Parameters.AddWithValue("@Height", cage.Height);
                    command.Parameters.AddWithValue("@Width", cage.Width);
                    command.Parameters.AddWithValue("@Length", cage.Length);

                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<ICage> GetAllItems()
        {
            const string sql = "SELECT * FROM Cages";

            var cagesList = new List<ICage>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cagesList.Add(new Cage((string)reader["type"]));
                        }
                    }
                }
            }
            return cagesList;
        }

        public ICage GetLastCreatedItem()
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
                            return new Cage(
                                (string)reader["type"],
                                (int)reader["height"],
                                (int)reader["width"],
                                (int)reader["length"] );
                        }
                    }
                }
            }
            return null;
        }
    }
}