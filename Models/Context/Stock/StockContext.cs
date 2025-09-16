using Microsoft.EntityFrameworkCore;
using StockWebApi.Models.Data.StockData;

namespace StockWebApi.Models.Context.Stock
{
    public class StockContext : DbContext
    {
        public DbSet<StockBaseData> StockBaseData { get; set; }

        public DbSet<StockOrderData> StockOrderData { get; set; }

        public DbSet<StockLastUpdatePrice> StockLastUpdatePrice { get; set; }

        public DbSet<StockTradesData> TradesData { get; set; }

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

            StockBaseDataCreating(modelBuilder);

            StockLastUpdatePriceCreating(modelBuilder);
        }

        private void StockTradesDataCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockTradesData>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }

        private void StockBaseDataCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockBaseData>(entity =>
            {
                entity.ToTable("StockBaseData");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }

        private void StockOrderCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockOrderData>(entity =>
            {
                entity.ToTable("StockOrder");

                //這裡是設定PK
                entity.HasKey(e => e.OrderId);

                //設定自動增加
                entity.Property(e => e.OrderId).ValueGeneratedOnAdd();

                entity.Property(e => e.StockCode).IsRequired();

                entity.Property(e => e.Quantity).IsRequired();

                entity.Property(e => e.OrderTime).IsRequired();

                entity.Property(e => e.OrderType).IsRequired();
            });
        }

        private void StockLastUpdatePriceCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockLastUpdatePrice>(entity =>
            {
                entity.ToTable("StockLastUpdatePrice");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.StockCode).IsRequired();

                entity.Property(e => e.Price).IsRequired();

                entity.Property(e => e.LastUpdateTime).IsRequired();
            });
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
