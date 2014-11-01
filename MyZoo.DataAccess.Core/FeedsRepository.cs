using System.Collections.Generic;
using System.Data.SqlClient;
using MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces;
using MyZoo.Common.Feeds;
using MyZoo.Common.Interfaces;


namespace MyZoo.DataAccess.Core
{
    public class FeedsRepository : Repository, IZooItemsRepository<IFeed>
    {
        public void Insert(IFeed feed)
        {
            const string sql =
               "INSERT INTO Feeds(ForWhich) Values(@ForWhich)";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ForWhich", feed.ToString());

                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<IFeed> GetAllItems()
        {
            const string sql = "SELECT * FROM Feeds";

            var feedsList = new List<IFeed>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            feedsList.Add(new Feed(
                                reader["ForWhom"].ToString(),
                                reader["Type"].ToString(),
                                (int)reader["specie"]));
                        }
                    }
                }

            }
            return feedsList;
        }

        public IFeed GetLastCreatedItem()
        {
            const string getEntities = "SELECT TOP 1 * FROM Feeds ORDER BY id DESC";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(getEntities, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new Feed(
                                reader["ForWhom"].ToString(),
                                reader["Type"].ToString(),
                                (int) reader["specie"]);
                        }
                    }
                }
            }
            return null;
        }
    }
}
