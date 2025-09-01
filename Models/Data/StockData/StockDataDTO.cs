namespace StockWebApi.Models.Data.StockData
{
    public class StockDataDTO
    {
        public string? StockCode { get; set; }

        public string? StockName { get; set; }

        public int StockType { get; set; }
        /// <summary>
        /// 當前價格
        /// </summary>
        public decimal? StockPrice { get; set; }

        /// <summary>
        /// 買進價
        /// </summary>
        public decimal? BuyInPrice { get; set; }
        /// <summary>
        /// 賣出價
        /// </summary>
        public decimal? SellPrice { get; set; }
        /// <summary>
        /// 當前單筆交易數量
        /// </summary>
        public int SingleTransactionAmount { get; set; }
        /// <summary>
        /// 當日目前總交易量
        /// </summary>
        public int TotalTransactionAmount { get; set; }
        /// <summary>
        /// 昨天收盤價格
        /// </summary>
        public decimal? YesterDayPrice { get; set; }

    }
}
