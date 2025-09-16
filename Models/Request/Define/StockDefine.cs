namespace StockWebApi.Models.Request.Define
{
    public enum StockType
    { 
        None,
        /// <summary>
        /// 食品業
        /// </summary>
        Food,
        /// <summary>
        /// 金融類
        /// </summary>
        Finance,
        /// <summary>
        /// 科技類
        /// </summary>
        Tech,
        /// <summary>
        /// 航運類
        /// </summary>
        Shipping,
        /// <summary>
        /// 旅遊類
        /// </summary>
        Travel,


        MAX
    }

    public enum StockOrderStatus
    {
        Order,  //下單
        Deal,   //成交
        Cancel, //取消
    }

    public enum StockOrderReturnCode : byte
    {
        Success,
        AccountNotExist,
        StockCodeNotExist,
        DataIsError,
    }

    public enum StockOrderType : byte
    { 
        Buyin,
        Sell
    }
}
