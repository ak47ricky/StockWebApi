using StockWebApi.Models.Data.StockData;
using StockWebApi.Models.Data.UserData;
using StockWebApi.Models.Request.Define;
using StockWebApi.Models.Request.Stock;
using StockWebApi.Repository;

namespace StockWebApi.Services
{
    public class StockService
    {
        private readonly StockRespository m_stockRespository;

        private readonly UserRepository m_userRepository;

        public StockService(StockRespository stockRespository, UserRepository userRepository) 
        { 
            m_stockRespository = stockRespository;

            m_userRepository = userRepository;
        }

        public async Task<StockBaseDataDTO> GetStockBaseDataDTO(string stockCode)
        {
            return await m_stockRespository.GetStockBaseDataDTO(stockCode);
        }

        public async Task<StockOrderReturnCode> StockOrder(ReqStockOrderData orderData)
        {
            if (CheckOrderData(orderData) == false)
                return StockOrderReturnCode.DataIsError;

            var accountDto = await m_userRepository.GetUserInfoDataDTO(orderData.Account);

            if (accountDto == null)
            {
                return StockOrderReturnCode.AccountNotExist;
            }

            var stockData = await m_stockRespository.GetStockBaseDataDTO(orderData.StockCode);

            if (stockData == null)
                return StockOrderReturnCode.StockCodeNotExist;

            StockOrderData stockOrder = new StockOrderData();

            stockOrder.Account = orderData.Account;

            stockOrder.AccountData = GetAccountData(accountDto);

            stockOrder.Quantity = orderData.Quantity;

            stockOrder.Price = orderData.Price;

            stockOrder.OrderType = orderData.OrderType;

            stockOrder.OrderTime = DateTime.Now;

            stockOrder.StockCode = orderData.StockCode;

            await m_stockRespository.StockOrder(stockOrder);

            return StockOrderReturnCode.Success;
        }

        private AccountData GetAccountData(UserBaseInfoDataDTO dataDTO)
        {
            return new AccountData
            {
                Id = dataDTO.UserId,
                GuidId = dataDTO.Guid,
                Account = dataDTO.Account,
                UserName = dataDTO.UserName,
            };
        }

        private bool CheckOrderData(ReqStockOrderData orderData)
        {
            if (orderData == null)
                return false;

            if (orderData.Quantity <= 0)
                return false;

            if (orderData.Price <= 0)
                return false;

            return true;
        }
    }
}
