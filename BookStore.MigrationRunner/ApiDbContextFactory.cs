using BookStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace BookStore.MigrationRunner
{
    public class ApiDbContextFactory : IDesignTimeDbContextFactory<ApiDbContext>
    {
        public ApiDbContext CreateDbContext(string[] args)
        {
            string? environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            environment = string.IsNullOrEmpty(environment) ? "Local" : environment;

            var configBuilder = new ConfigurationBuilder();
            configBuilder
                .AddCommandLine(args)
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables();

            var config = configBuilder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();

            var cs = ConnectionStringProvider.GetConnectionString(config);

            NpgsqlConnectionStringBuilder builder = new NpgsqlConnectionStringBuilder(cs);

            optionsBuilder.UseNpgsql(builder.ConnectionString);

            return new ApiDbContext(optionsBuilder.Options);
        }
    }
}