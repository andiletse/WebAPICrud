using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace DAL.Helpers
{
    public sealed class ConnSqlHelper
    {
        public string GetConnectionStringFromDbContext()
        {
            // Access the connection string from the DbContext's Database property
            using (var dbContext = new PersonDbContext())
            {
                var connection = dbContext.Database.GetDbConnection();
                return connection.ConnectionString;
            }
        }
    }
}
