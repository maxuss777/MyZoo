using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MyZoo.Common.Interfaces;


namespace MyZoo.DataAccess.Core
{
    public class AnimalsRepository : Repository, IZooItemsRepository<IAnimal>
    {
        public void Insert(IAnimal animal)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("InsertAnimal", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    #region Input parameters

                    var param = new SqlParameter
                        {
                            ParameterName = "@specie",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Value = animal.GetType().Name,
                            Direction = ParameterDirection.Input
                        };
                    command.Parameters.Add(param);

                    param = new SqlParameter
                    {
                        ParameterName = "@kind",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Value = animal.Kind,
                        Direction = ParameterDirection.Input
                    };
                    command.Parameters.Add(param);

                    param = new SqlParameter
                    {
                        ParameterName = "@name",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Value = animal.Name,
                        Direction = ParameterDirection.Input
                    };
                    command.Parameters.Add(param);

                    param = new SqlParameter
                    {
                        ParameterName = "@food",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Value = animal.Food,
                        Direction = ParameterDirection.Input
                    };
                    command.Parameters.Add(param);

                    param = new SqlParameter
                    {
                        ParameterName = "@cageId",
                        SqlDbType = SqlDbType.Int,
                        Size = 10,
                        Value = animal.CageId,
                        Direction = ParameterDirection.Input
                    };
                    command.Parameters.Add(param);

                    #endregion

                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<IAnimal> GetAllItems()
        {
            var animalsList = new List<IAnimal>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("GetAllAnimals", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string str = string.Format("MyZoo.Common.ZooItems.{0}, MyZoo.Common.Animal", reader["specie"]);

                            var type = Type.GetType(str);

                            if (type != null)
                            {
                                animalsList.Add(
                                    (IAnimal)Activator.CreateInstance(
                                    type, 
                                    reader["id"],
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

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("GetLastCreatedAnimal", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        while(reader.Read())
                        {
                            var str = 
                                string.Format(
                                "MyZoo.Common.ZooItems.{0}, MyZoo.Common.Animal", reader["specie"]);
                            
                            var type = Type.GetType(str);

                            if(type != null)
                            {
                                return (IAnimal)Activator.CreateInstance(
                                    type, 
                                    reader["id"],
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