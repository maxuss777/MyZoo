using System.Collections.Generic;
using System.Data.SqlClient;
using MyZoo.Common.Feeds;
using MyZoo.Common.Interfaces;


namespace MyZoo.DataAccess.Core
{
    public class FeedsRepository : Repository, IZooItemsRepository<Feeds>
    {
        public void Insert(Feeds feed)
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

        public IEnumerable<Feeds> GetAllItems()
        {
            const string sql = "SELECT * FROM Feeds";

            var feedsList = new List<Feeds>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            switch (reader["ForWhich"].ToString())
                            {
                                case "ForMammal":
                                    feedsList.Add(Feeds.ForMammal);
                                    break;
                                case "ForBird":
                                    feedsList.Add(Feeds.ForBird);
                                    break;
                                case "ForReptile":
                                    feedsList.Add(Feeds.ForReptile);
                                    break;
                                case "ForFish":
                                    feedsList.Add(Feeds.ForFish);
                                    break;
                            }
                        }
                    }
                }

            }
            return feedsList;
        }

        public Feeds GetLastCreatedItem()
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
                            switch (reader["ForWhich"].ToString())
                            {
                                case "ForMammal":
                                    return Feeds.ForMammal;

                                case "ForBird":
                                    return Feeds.ForBird;

                                case "ForReptile":
                                    return Feeds.ForReptile;
                            }
                        }
                    }
                }
            }
            return Feeds.NoOne;
        }
    }
}
