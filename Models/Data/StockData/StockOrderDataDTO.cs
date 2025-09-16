namespace StockWebApi.Models.Data.StockData
{
    public class StockOrderDataDTO
    {
        public int Id { get; set; }

        public string? StockName { get; set; }

        public string? StockCode { get; set; }

        public decimal? Price { get; set; }

        public int Amount { get; set; }

        public byte OrderStatus { get; set; }

        public DateTime OrderTime { get; set; }
    }
}
