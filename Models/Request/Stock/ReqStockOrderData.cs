namespace StockWebApi.Models.Request.Stock
{
    public class ReqStockOrderData
    {
        public string? Account { get; set; }

        public string? StockCode { get; set; }

        public byte OrderType { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
