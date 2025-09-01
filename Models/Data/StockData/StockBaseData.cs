namespace StockWebApi.Models.Data.StockData
{
    public class StockBaseData
    {
        public int Id { get; set; }

        public string? StockCode { get; set; }

        public string? StockName { get; set; }

        public int StockType { get; set; }
        
        public decimal? Price { get; set; }
    }
}
