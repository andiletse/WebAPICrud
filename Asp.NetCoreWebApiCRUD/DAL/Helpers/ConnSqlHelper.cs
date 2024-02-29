using Microsoft.Extensions.Configuration;
namespace DAL.Helpers
{
    public sealed class ConnSqlHelper
    {
        public ConnSqlHelper(string connectionString)
        {
            connectionString = connectionString;
        }
        public string ConnectionString { get; }
    }
}
