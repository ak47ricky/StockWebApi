using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StockWebApi.Models.Context
{
    public class UserContextFactory : IDesignTimeDbContextFactory<UserContext>
    {
        public UserContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            var connectionString = config.GetConnectionString("WebDatabase");

            var builder = new DbContextOptionsBuilder<UserContext>();

            builder.UseSqlServer(connectionString);

            return new UserContext(builder.Options);
        }
    }
}
