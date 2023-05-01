using ContentLibrary.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ContentLibrary.DataAccess
{
    public class SqlDataAccess
    {
        private readonly string _sqlConnectionString;

        public SqlDataAccess(string connectionString)
        {
            _sqlConnectionString = connectionString;
        }

/*        public static string GetConnectionString(string connectionName = "SQLDbConnection")
        {
            //return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            //return _configuration.GetConnectionString(connectionName);

            return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ContentDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }*/

        public List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(_sqlConnectionString))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(_sqlConnectionString))
            {
                
                return cnn.Execute(sql, data);
            }
        }
    }
}
