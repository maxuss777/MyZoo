using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MyZoo.Common.Interfaces;


namespace MyZoo.DataAccess.Core
{
    public class AnimalsRepository : Repository, IZooItemsRepository<IAnimal>
    {
        public void Insert(IAnimal animal)
        {
            const string sql =
                "INSERT INTO Animals(specie, kind, name, food, cageId) Values(@Specie, @Kind, @Name, @Food, @CageId)";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Specie", animal.GetType().Name);
                    command.Parameters.AddWithValue("@Kind", animal.Kind);
                    command.Parameters.AddWithValue("@Name", animal.Name);
                    command.Parameters.AddWithValue("@Food", animal.Food);
                    command.Parameters.AddWithValue("@CageId", animal.CageId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<IAnimal> GetAllItems()
        {
            const string sql = "SELECT * FROM Animals";

            var animalsList = new List<IAnimal>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string str = string.Format(
                                "MyZoo.Common.ZooItems.Species.{0}, MyZoo.Common.Animal", reader["specie"]);
                            var type = Type.GetType(str);

                            if (type != null)
                            {
                                animalsList.Add(
                                    (IAnimal)Activator.CreateInstance(
                                    type, 
                                    reader["kind"],
                                    reader["name"],
                                    reader["food"],
                                    reader["cageId"]));
                            }
                        }
                    }
                }
            }

            return animalsList;
        }

        public IAnimal GetLastCreatedItem()
        {
            const string sql = "SELECT TOP 1 * FROM Animals ORDER BY id DESC";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            var str = 
                                string.Format(
                                "MyZoo.Common.ZooItems.Species.{0}, MyZoo.Common.Animal", reader["specie"]);
                            
                            var type = Type.GetType(str);

                            if(type != null)
                            {
                                return (IAnimal)Activator.CreateInstance(
                                    type, 
                                    reader["kind"],
                                    reader["name"],
                                    reader["food"],
                                    reader["cageId"]);
                            }
                        }
                    }
                }
            }
            
            return null;
        }
    }
}