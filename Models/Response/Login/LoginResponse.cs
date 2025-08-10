namespace StockWebApi.Models.Response.Login
{
    public enum LoginReturnCode
    {
        Success,
        AccountOrPasswardFail,
        ParmIsEmpty
    }

    public class LoginResponse
    {
        public LoginReturnCode ReturnCode { get; set; }

        public string? Key { get; set; }
    }
}
