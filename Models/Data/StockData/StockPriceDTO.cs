namespace StockWebApi.Models.Data.StockData
{
    public class StockPriceDTO
    {
        public int Id { get; set; }

        public string? StockName { get; set; }

        public string? StockCode { get; set; }

        public int StockType { get; set; }

        public decimal? Price { get; set; }
    }
}
