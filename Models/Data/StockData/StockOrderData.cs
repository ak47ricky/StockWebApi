namespace StockWebApi.Models.Data.StockData
{
    public class StockOrderData
    {
        public int OrderId { get; set; } //PK

        public string? Account { get; set; } //FK

        public string? StockCode { get; set; }

        public byte OrderType { get; set; }

        public decimal Quantity { get; set; }

        public DateTime OrderTime { get; set; }
    }
}
