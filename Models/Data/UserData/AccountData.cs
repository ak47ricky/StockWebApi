namespace StockWebApi.Models.Data.UserData
{
    public class AccountData
    {
        public int Id { get; set; }

        public Guid GuidId { get; set; }

        public string? UserName { get; set; }

        public string? Account { get; set; }

        public int Permissions { get; set; }
    }
}
