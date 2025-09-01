using Microsoft.EntityFrameworkCore;
using StockWebApi.Models.Data.StockData;

namespace StockWebApi.Models.Context.Stock
{
    public class StockContext : DbContext
    {
        public DbSet<StockBaseData> StockBaseData { get; set; }

        public StockContext()
        {

        }

        public StockContext(DbContextOptions<StockContext> options) : base(options)
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            StockOrderCreating(modelBuilder);
        }

        private void StockOrderCreating(ModelBuilder modelBuilder)
        {

        }

        private void StockTradesCreating(ModelBuilder modelBuilder) 
        { 
        
        }

        private void StockPriceCreating(ModelBuilder modelBuilder)
        {

        }

        private void StockHoldingsCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
