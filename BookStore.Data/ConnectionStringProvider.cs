using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Configuration;

namespace BookStore.Data
{
    public static class ConnectionStringProvider
    {
        public static string GetConnectionString(IConfiguration configuration)
        {
            var builder = configuration.GetSection("ConnectionStrings:PostgresDb").Get<NpgsqlConnectionStringBuilder>();

            if (builder is null)
            {
                throw new ConfigurationErrorsException("Failed to construct connection string");
            }

            return builder.ConnectionString;
        }
    }
}