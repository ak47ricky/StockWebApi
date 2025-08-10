using StockWebApi.CommonFun;
using StockWebApi.Models.Context;
using StockWebApi.Models.Request.Login;
using StockWebApi.Models.Response.Login;

namespace StockWebApi.Repository
{
    public class LoginRepository
    {
        private UserContext m_userContext;

        public LoginRepository(UserContext userContext)
        {
            m_userContext = userContext;
        }

        public LoginReturnCode Login(LoginPost loginPost)
        {
            LoginResponse loginResponse = new LoginResponse();

            if (loginPost.IsDataEmpty())
            {
                loginResponse.ReturnCode = LoginReturnCode.ParmIsEmpty;

                return LoginReturnCode.ParmIsEmpty;
            }

            var reuslt = (from a in m_userContext.UserBaseInfoData
                          where loginPost.Account == a.Account
                          select a).SingleOrDefault();

            if (reuslt == null)
            {
                return LoginReturnCode.AccountOrPasswardFail;
            }

            var passWordSalt = reuslt.PasswordSalt;

            var passWordHash = Sha256CreateHash.GetHashCode(loginPost.Password, passWordSalt);

            if (passWordHash != reuslt.PasswordHash)
            {
                return LoginReturnCode.AccountOrPasswardFail;
            }

            return LoginReturnCode.Success;
        }
    }
}
