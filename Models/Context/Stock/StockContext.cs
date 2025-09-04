using Microsoft.EntityFrameworkCore;
using StockWebApi.Models.Data.StockData;

namespace StockWebApi.Models.Context.Stock
{
    public class StockContext : DbContext
    {
        public DbSet<StockBaseData> StockBaseData { get; set; }

        public DbSet<StockOrderData> StockOrderData { get; set; }

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

                entity.HasOne(e => e.AccountData)
                .WithMany()//如果需要雙向關聯 就設定在這邊
                .HasForeignKey(e => e.Account)
                .HasPrincipalKey(e => e.Account);

                entity.Property(e => e.StockCode).IsRequired();

                entity.Property(e => e.Quantity).IsRequired();

                entity.Property(e => e.OrderTime).IsRequired();

                entity.Property(e => e.OrderType).IsRequired();
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
