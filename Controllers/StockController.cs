using Microsoft.AspNetCore.Http;
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
    }
}
