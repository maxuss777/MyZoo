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
    }
}
