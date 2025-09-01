using Microsoft.IdentityModel.Tokens;
using StockWebApi.CommonFun;
using StockWebApi.Models.Context.User;
using StockWebApi.Models.Data.UserData;
using StockWebApi.Models.Request.Login;
using StockWebApi.Models.Response.Login;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StockWebApi.Repository
{
    public class LoginRepository
    {
        private UserContext m_userContext;

        private IConfiguration m_configuration;

        public LoginRepository(UserContext userContext, IConfiguration configuration)
        {
            m_userContext = userContext;

            m_configuration = configuration;
        }

        public LoginResponse Login(LoginPost loginPost)
        {
            LoginResponse loginResponse = new LoginResponse();

            if (loginPost.IsDataEmpty())
            {
                loginResponse.ReturnCode = LoginReturnCode.ParmIsEmpty;

                return loginResponse;
            }

            var result = (from a in m_userContext.UserBaseInfoData
                          where loginPost.Account == a.Account
                          select a).SingleOrDefault();

            if (result == null)
            {
                loginResponse.ReturnCode = LoginReturnCode.AccountOrPasswardFail;

                return loginResponse;
            }

            var passWordSalt = result.PasswordSalt;

            var passWordHash = Sha256CreateHash.GetHashCode(loginPost.Password, passWordSalt);

            if (passWordHash != result.PasswordHash)
            {
                loginResponse.ReturnCode = LoginReturnCode.AccountOrPasswardFail;

                return loginResponse;
            }

            loginResponse.Account = loginPost.Account;

            loginResponse.UserPermissionType = (Models.Request.Define.UserPermissionType)result.Permissions;

            loginResponse.Key = GetJwtKey(result);

            loginResponse.ReturnCode = LoginReturnCode.Success;

            return loginResponse;
        }

        public string GetJwtKey(UserBaseInfoData userBaseInfoData)
        {
            //金鑰
            var key =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(m_configuration["JWT:Key"]));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>()
            {
                new Claim("Account", userBaseInfoData.Account),
                new Claim("Permissions" , userBaseInfoData.Permissions.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: m_configuration["JWT:Key"],
                audience: m_configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddSeconds(60),
                signingCredentials: cred
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
