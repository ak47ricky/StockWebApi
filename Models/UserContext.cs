using Microsoft.EntityFrameworkCore;
using StockWebApi.Models.UserData;

namespace StockWebApi.Models
{
    public class UserContext : DbContext
    {

        public DbSet<UserBaseInfoData> UserBaseInfoData { get; set; }

        //加上這段 是用於在Progress註冊這個context
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        //這邊是code first 建立表格欄位
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //這邊是設定主鍵
            modelBuilder.Entity<UserBaseInfoData>().HasKey(e => e.Id);

            //接下來就是幫有特殊需求的欄位加上設定
            modelBuilder.Entity<UserBaseInfoData>(entity => 
            { 
                //entity.Property(e => e.CreatedTime).HasDefaultValue
            });


        }
    }
}
