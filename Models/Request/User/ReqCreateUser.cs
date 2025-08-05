namespace StockWebApi.Models.Request.User
{
    public class ReqCreateUser
    {
        public string? UserName { get; set; }

        public string? Account { get; set; }

        public string? Password { get; set; }

        public string? Mail { get; set; }
    }
}
