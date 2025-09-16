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

        public async Task<StockOrderReturnCode> DeleteOrderData(int id)
        {
            if (await m_stockRespository.TryDeleteOrderData(id) == false)
                return StockOrderReturnCode.DataIsError;

            return StockOrderReturnCode.Success;
        }

        public async Task<StockOrderReturnCode> StockOrder(ReqStockOrderData orderData)
        {
            if (CheckOrderData(orderData) == false)
                return StockOrderReturnCode.DataIsError;

            var accountDto = await m_userRepository.GetUserInfoDataDTO(orderData.Account);

            if (await CheckAccount(orderData.Account) == false)
            {
                return StockOrderReturnCode.AccountNotExist;
            }

            var stockData = await m_stockRespository.GetStockBaseDataDTO(orderData.StockCode);

            if (stockData == null)
                return StockOrderReturnCode.StockCodeNotExist;

            StockOrderData stockOrder = new StockOrderData();

            stockOrder.Account = orderData.Account;

            stockOrder.Quantity = orderData.Quantity;

            stockOrder.Price = orderData.Price;

            stockOrder.OrderType = orderData.OrderType;

            stockOrder.OrderTime = DateTime.Now;

            stockOrder.StockCode = orderData.StockCode;

            await m_stockRespository.StockOrder(stockOrder);

            return StockOrderReturnCode.Success;
        }

        public async Task<(StockOrderReturnCode, List<StockOrderDataDTO>?)> GetStockOrderDTO(string account)
        {
            if (await CheckAccount(account) == false)
            {
                return (StockOrderReturnCode.AccountNotExist, null);
            }

            var result = m_stockRespository.GetStockOrderData(account);

            if (result == null)
            {
                return (StockOrderReturnCode.DataIsError, null);
            }

            return (StockOrderReturnCode.Success, result.Result);
        }

        public async Task<List<StockPriceDTO>> GetStockPriceList()
        {
            return await m_stockRespository.GetStockPriceList();
        }

        private AccountData GetAccountData(UserBaseInfoDataDTO dataDTO)
        {
            return new AccountData
            {
                GuidId = dataDTO.Guid,
                Account = dataDTO.Account,
                UserName = dataDTO.UserName,
            };
        }

        private async Task<bool> CheckAccount(string account)
        {
            var result = await m_userRepository.GetUserInfoDataDTO(account);

            return result != null;
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