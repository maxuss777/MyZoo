using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MyZoo.Common.Interfaces;
using MyZoo.Common.ZooItems;


namespace MyZoo.DataAccess.Core
{
    public class CagesRepository : Repository, IZooItemsRepository<ICage>
    {
        public void Insert(ICage cage)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("InsertCage", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    #region Input parameters

                    var param = new SqlParameter
                    {
                        ParameterName = "@type",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Value = cage.Type,
                        Direction = ParameterDirection.Input
                    };
                    command.Parameters.Add(param);

                    param = new SqlParameter
                    {
                        ParameterName = "@height",
                        SqlDbType = SqlDbType.Int,
                        Size = 10,
                        Value = cage.Height,
                        Direction = ParameterDirection.Input
                    };
                    command.Parameters.Add(param);

                    param = new SqlParameter
                    {
                        ParameterName = "@width",
                        SqlDbType = SqlDbType.Int,
                        Size = 10,
                        Value = cage.Width,
                        Direction = ParameterDirection.Input
                    };
                    command.Parameters.Add(param);

                    param = new SqlParameter
                    {
                        ParameterName = "@length",
                        SqlDbType = SqlDbType.Int,
                        Size = 10,
                        Value = cage.Length,
                        Direction = ParameterDirection.Input
                    };
                    command.Parameters.Add(param);
                    

                    #endregion

                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<ICage> GetAllItems()
        {
            var cagesList = new List<ICage>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("GetAllCages", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cagesList.Add(new Cage((int)reader["id"], (string)reader["type"]));
                        }
                    }
                }
            }
            return cagesList;
        }

        public ICage GetLastCreatedItem()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("GetLastCreatedCage", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        while (reader.Read())
                        {
                            return new Cage(
                                (int) reader["id"],
                                (string) reader["type"],
                                (int) reader["height"],
                                (int) reader["width"],
                                (int) reader["length"]);
                        }
                    }
                }
            }
            return null;
        }
    }
}