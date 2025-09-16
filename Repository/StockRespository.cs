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
            try
            {
                var result = await m_stockContext.StockBaseData
            .Where(a => a.StockCode == stockCode)
            .Select(a => new StockBaseDataDTO
            {
                StockCode = a.StockCode,
                StockName = a.StockName,
                StockPrice = a.Price

            }).SingleOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<bool> TryDeleteOrderData(int id)
        {
            var result = await m_stockContext.StockOrderData
                .Where(data => data.OrderId == id)
                .FirstOrDefaultAsync();

            if (result == null)
                return false;

            m_stockContext.StockOrderData.Remove(result);

            await m_stockContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<StockOrderDataDTO>> GetStockOrderData(string account)
        {
            var result = await
                (
                    from order in m_stockContext.StockOrderData
                    join stockData in m_stockContext.StockBaseData
                    on order.StockCode equals stockData.StockCode
                    where order.Account == account
                    orderby order.OrderTime
                    select new StockOrderDataDTO()
                    {
                        Id = order.OrderId,
                        StockCode= order.StockCode,
                        StockName = stockData.StockName,
                        OrderTime = order.OrderTime,
                        Price = order.Price,
                        Amount = order.Quantity,
                        OrderStatus = order.OrderStatus
                    }).ToListAsync();


            return result;
        }

        public async Task StockOrder(StockOrderData orderData)
        {
            try
            {
                await m_stockContext.AddAsync(orderData);

                await m_stockContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }

        public async Task<List<StockPriceDTO>> GetStockPriceList()
        {
            var result = await (from price in m_stockContext.StockLastUpdatePrice.AsNoTracking()
                                join stockData in m_stockContext.StockBaseData
                                on price.StockCode equals stockData.StockCode
                                select new StockPriceDTO()
                                {
                                    Id = price.Id,
                                    Price = price.Price,
                                    StockCode = stockData.StockCode,
                                    StockName = stockData.StockName,
                                    StockType = stockData.StockType
                                }).ToListAsync();

            return result;
        }
    }
}
