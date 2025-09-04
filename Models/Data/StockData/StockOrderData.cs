using StockWebApi.Models.Data.UserData;

namespace StockWebApi.Models.Data.StockData
{
    public class StockOrderData
    {
        public int OrderId { get; set; } //PK

        public string? Account { get; set; } //FK

        public AccountData? AccountData { get; set; }

        public string? StockCode { get; set; }

        public byte OrderType { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public DateTime OrderTime { get; set; }
    }
}
