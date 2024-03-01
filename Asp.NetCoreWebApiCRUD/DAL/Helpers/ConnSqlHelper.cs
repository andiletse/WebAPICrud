using Microsoft.Extensions.Configuration;
namespace DAL.Helpers
{
    public sealed class ConnSqlHelper
    {
        public ConnSqlHelper(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public string ConnectionString { get; }
    }
}
