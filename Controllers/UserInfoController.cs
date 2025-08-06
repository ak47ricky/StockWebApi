using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockWebApi.Models.Request.User;
using StockWebApi.Services;

namespace StockWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private UserService m_userService;

        public UserInfoController(UserService userService) 
        {
            m_userService = userService;
        }

        [HttpPost("User/Create")]
        public async Task<IActionResult> CreateUser([FromBody] ReqCreateUser reqCreateUser)
        {
            var result = await m_userService.CreateUser(reqCreateUser);

            switch (result)
            {
                case Models.Request.Define.CreateUserStatus.DataFail:
                    return BadRequest("有資料為空");
                case Models.Request.Define.CreateUserStatus.ExistUsers:
                    return Conflict();
                case Models.Request.Define.CreateUserStatus.Success:
                    return Created();
            }
            return StatusCode(500);
        }
    }
}
