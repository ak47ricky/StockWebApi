namespace StockWebApi.Models.Data.StockData
{
    public class StockTradesData
    {
        public int Id { get; set; }

        public string? BuyinAccount { get; set; }

        public string? SellAccount { get; set; }

        public string? StockCode { get; set; }

        public int TradeAmount { get; set; }

        public decimal TradePrice { get; set; }

        public DateTime TradeTime { get; set; }
        
    }
}
