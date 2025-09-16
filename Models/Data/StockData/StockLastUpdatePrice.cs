namespace StockWebApi.Models.Data.StockData
{
    public class StockLastUpdatePrice
    {
        public int Id { get; set; }

        public string? StockCode { get; set; }

        public decimal Price { get; set; }

        public DateTime LastUpdateTime { get; set; }
    }
}
