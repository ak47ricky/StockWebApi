namespace StockWebApi.Models.UserData
{
    public class UserBaseInfoData
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public string? UserName { get; set; }

        public string? Account { get; set; }

        public string? PasswordHash { get; set; }

        public string? PasswordSalt { get; set; }

        public string? Email { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public DateTime LastLoginTime { get; set; }

        public int Permissions { get; set; }
    }
}
