using Microsoft.EntityFrameworkCore;
using StockWebApi.Models.Data.UserData;

namespace StockWebApi.Models.Context.User
{
    public class UserContext : DbContext
    {
        public UserContext()
        {

        }

        public DbSet<UserBaseInfoData> UserBaseInfoData { get; set; }

        public DbSet<AccountData> AccountData { get; set; }

        //加上這段 是用於在Progress註冊這個context
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        //這邊是code first 建立表格欄位
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            CreateUserBaseInfo(modelBuilder);

            CreateAccountData(modelBuilder);
        }

        private void CreateUserBaseInfo(ModelBuilder modelBuilder)
        {
            //這邊是設定主鍵
            modelBuilder.Entity<UserBaseInfoData>().HasKey(e => e.Id);

            //接下來就是幫有特殊需求的欄位加上設定
            //HasMaxLength 若不設定 string 部分就會是MAX
            modelBuilder.Entity<UserBaseInfoData>()
                .HasOne(u => u.AccountData)
                .WithOne(a => a.UserBaseInfoData)
                .HasForeignKey<UserBaseInfoData>(u => u.AccountId);

            modelBuilder.Entity<UserBaseInfoData>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn();
                entity.Property(e => e.UserName).HasMaxLength(50);
                entity.Property(e => e.PasswordSalt).HasMaxLength(250);
                entity.Property(e => e.PasswordHash).HasMaxLength(250);
                entity.Property(e => e.Email).HasMaxLength(250);
                //這邊需要注意 如果是要取SQL東西 需要用HasDefaultValueSql
                entity.Property(e => e.CreatedTime).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.UpdateTime).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.LastLoginTime).HasDefaultValueSql("GETDATE()");
            });
        }

        private void CreateAccountData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountData>().HasKey(entity => entity.Id);

            modelBuilder.Entity<AccountData>(entity =>
            {
                entity.Property(a => a.Id).UseIdentityColumn();
            });
        }
    }
}
