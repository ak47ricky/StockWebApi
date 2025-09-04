using Microsoft.EntityFrameworkCore;
using StockWebApi.Models.Context.Stock;
using StockWebApi.Models.Data.StockData;

namespace StockWebApi.Repository
{
    public class StockRespository
    {
        private readonly StockContext m_stockContext;

        public StockRespository(StockContext stockContext) 
        {
            m_stockContext = stockContext;
        }

        public async Task<StockBaseDataDTO> GetStockBaseDataDTO(string stockCode)
        {
            var result = await m_stockContext.StockBaseData
                        .Where(a=>a.StockCode == stockCode)
                        .Select(a=> new StockBaseDataDTO{
                        StockCode = a.StockCode,
                        StockName = a.StockName,
                        StockPrice = a.Price

                        }).SingleOrDefaultAsync();

            return result;
        }

        public async Task StockOrder(StockOrderData orderData)
        {
            await m_stockContext.AddAsync(orderData);
        }
    }
}
