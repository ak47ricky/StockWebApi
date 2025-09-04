using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StockWebApi.Models.Context.Stock
{
    public class StockContextFactory : IDesignTimeDbContextFactory<StockContext>
    {
        public StockContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();

            var connectionString = config.GetConnectionString("WebDatabase");

            var builder = new DbContextOptionsBuilder<StockContext>();

            builder.UseSqlServer(connectionString);

            return new StockContext(builder.Options);
        }
    }
}
