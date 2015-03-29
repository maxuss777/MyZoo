using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces;
using MyZoo.Common.Animal.Interfaces.DataAccess.Core.Interfaces;
using MyZoo.Common.ZooItems;


namespace MyZoo.DataAccess.Core
{
    public class FeedsRepository : Repository, IZooItemsRepository<IFeed>
    {
        public void Insert(IFeed feed)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("InsertFeed", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    #region Input parameters

                    var param = new SqlParameter
                    {
                        ParameterName = "@type",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Value = feed.Type,
                        Direction = ParameterDirection.Input
                    };
                    command.Parameters.Add(param);

                    param = new SqlParameter
                    {
                        ParameterName = "@gross",
                        SqlDbType = SqlDbType.Int,
                        Size = 10,
                        Value = feed.Gross,
                        Direction = ParameterDirection.Input
                    };
                    command.Parameters.Add(param);

                    param = new SqlParameter
                    {
                        ParameterName = "@forWhom",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Value = feed.ForWhom,
                        Direction = ParameterDirection.Input
                    };
                    command.Parameters.Add(param);

                    #endregion
                    
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<IFeed> GetAllItems()
        {
            var feedsList = new List<IFeed>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("GetAllFeeds", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        while (reader.Read())
                        {
                            feedsList.Add(
                                new Feed(
                                    (int) reader["id"],
                                    (string) reader["type"],
                                    (int) reader["gross"],
                                    (string) reader["forWhom"])
                                );
                        }
                    }
                }
            }
            return feedsList;
        }

        public IFeed GetLastCreatedItem()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("GetLastCreatedFeed", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return
                                new Feed(
                                    (int) reader["id"],
                                    (string) reader["type"],
                                    (int) reader["gross"],
                                    (string) reader["forWhom"]
                                    );
                        }
                    }
                }
            }
            return null;
        }
    }
}
