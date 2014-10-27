using System.Collections.Generic;
using System.Data.SqlClient;
using MyZoo.Common.ZooItems.BaseClasses;
using MyZoo.Common.Interfaces;



namespace MyZoo.DataAccess.Core
{
    public class AnimalsRepository : Repository, IZooItemsRepository<IZooItems<Animal>>
    {
        public void Insert(IZooItems<Animal> animal)
        {
            const string sql =
                "INSERT INTO Animals(specie, kind) Values(@specie, @kind)";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@specie", animal.Specie);
                    command.Parameters.AddWithValue("@kind", animal.Kind);

                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<IZooItems<Animal>> GetAllItems()
        {
            const string sql = "SELECT * FROM Animals";

            var animalsList = new List<IZooItems<Animal>>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            animalsList.Add(new Animal(
                                                reader["specie"].ToString(),
                                                reader["kind"].ToString()));
                        }
                    }
                }
            }

            return animalsList;
        }

        public IZooItems<Animal> GetLastCreatedItem()
        {
            const string sql = "SELECT TOP 1 * FROM Animals ORDER BY id DESC";

            IZooItems<Animal> animal = null;

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            animal = new Animal(
                                reader["specie"].ToString(),
                                reader["kind"].ToString());
                        }
                    }
                }
            }

            return animal;
        }
    }
}