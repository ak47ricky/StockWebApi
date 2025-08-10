using Microsoft.AspNetCore.Mvc;
using StockWebApi.Models.Context;
using StockWebApi.Models.Response.Login;

namespace StockWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private UserContext m_userContext;

        public LoginController(UserContext userContext)
        {
            m_userContext = userContext;
        }

        public IActionResult Login(string username, string password)
        {
            LoginResponse loginResponse = new LoginResponse();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                loginResponse.ReturnCode = LoginReturnCode.ParmIsEmpty;

                return BadRequest(loginResponse);
            }

            var result = (from a in m_userContext.UserBaseInfoData
                          where username == a.UserName
                          select a).SingleOrDefault();

            if (result == null)
            {
                loginResponse.ReturnCode = LoginReturnCode.AccountOrPasswardFail;

                return BadRequest(loginResponse);
            }

        }
    }
}
