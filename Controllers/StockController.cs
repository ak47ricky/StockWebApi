using Microsoft.AspNetCore.Mvc;
using StockWebApi.Models.Data.StockData;
using StockWebApi.Models.Request.Stock;
using StockWebApi.Services;

namespace StockWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockService m_stockService;

        public StockController(StockService stockService)
        {
            m_stockService = stockService;
        }

        [HttpGet("StockData")]
        public async Task<ActionResult<StockBaseDataDTO>> GetStockBaseData(string stockCode)
        {
            var result = await m_stockService.GetStockBaseDataDTO(stockCode);

            if (result == null)
            {
                return NotFound("code is error");
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost("Order")]
        public async Task<IActionResult> StockOrder([FromBody] ReqStockOrderData orderData)
        {
            var result =await m_stockService.StockOrder(orderData);

            if (result != Models.Request.Define.StockOrderReturnCode.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpDelete("Order/{id:int}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await m_stockService.DeleteOrderData(id);

            if (result != Models.Request.Define.StockOrderReturnCode.Success)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("OrderStockData")]
        public async Task<ActionResult<List<StockOrderDataDTO>>> GetStockOrderData(string account)
        {
            var result = await m_stockService.GetStockOrderDTO(account);

            if (result.Item1 != Models.Request.Define.StockOrderReturnCode.Success)
            {
                return BadRequest(result.Item1);
            }
            
            return Ok(result.Item2);
        }

        [HttpGet("StockPrice")]
        public async Task<ActionResult<List<StockPriceDTO>>> GetStockPriceList()
        {
            var result = await m_stockService.GetStockPriceList();

            if (result == null || result.Any() == false)
                return NotFound();

            return Ok(result);
        }
    }
}
