namespace StockWebApi.Models.Request.Login
{
    public class LoginPost
    {
        public string? Account { get; set; }

        public string? Password { get; set; }

        public bool IsDataEmpty()
        {
            return string.IsNullOrEmpty(Account) || string.IsNullOrEmpty(Password);
        }
    }
}
