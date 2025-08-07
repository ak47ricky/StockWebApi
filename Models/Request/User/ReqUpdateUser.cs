namespace StockWebApi.Models.Request.User
{
    public class ReqUpdateUser
    {
        public string? Account { get; set; }

        public string? Password { get; set; }

        public string? Mail { get; set; }
    }
}
