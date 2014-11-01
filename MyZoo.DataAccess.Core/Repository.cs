using System.Configuration;

namespace MyZoo.DataAccess.Core
{
    public class Repository
    {
        protected static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString; }
        }
    }
}
