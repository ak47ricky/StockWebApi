using Microsoft.AspNetCore.Mvc;
using StockWebApi.Models.Context;
using StockWebApi.Models.Request.Login;
using StockWebApi.Models.Response.Login;
using StockWebApi.Repository;

namespace StockWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginRepository m_loginRepository;

        public LoginController(LoginRepository loginRepository)
        {
            m_loginRepository = loginRepository;
        }

        public IActionResult Login(LoginPost loginPost)
        {
            var loginResult = m_loginRepository.Login(loginPost);

            LoginResponse loginResponse = new LoginResponse();

            loginResponse.ReturnCode = loginResult;

            if (loginResult != LoginReturnCode.Success)
            {
                return BadRequest(loginResult);
            }
            else
            {
                return Ok(loginResult);
            }
        }
    }
}
