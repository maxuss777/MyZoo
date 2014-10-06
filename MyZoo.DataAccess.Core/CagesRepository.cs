using System.Collections.Generic;
using System.Data.SqlClient;
using MyZoo.Common.Cages;


namespace MyZoo.DataAccess.Core
{
    public class CagesRepository : Repository
    {
        public void Insert(Cages cages)
        {
            const string sql =
               "INSERT INTO Cages(ForWhich) Values(@ForWhich)";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ForWhich", cages.ToString());

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Cages> GetAll()
        {
            const string sql = "SELECT * FROM Cages";

            var cagesList = new List<Cages>();

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
                                    cagesList.Add(Cages.ForMammal);
                                    break;
                                case "ForBird":
                                    cagesList.Add(Cages.ForBird);
                                    break;
                                case "ForReptile":
                                    cagesList.Add(Cages.ForReptile);
                                    break;
                            }
                        }
                    }
                }

            }
            return cagesList;
        }

        public Cages GetLastCreatedCage()
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
                            switch (reader["ForWhich"].ToString())
                            {
                                case "ForMammal":
                                    return Cages.ForMammal;

                                case "ForBird":
                                    return Cages.ForBird;

                                case "ForReptile":
                                    return Cages.ForReptile;
                            }
                        }
                    }
                }
            }
            return Cages.NoOne;
        }
        
    }
}
