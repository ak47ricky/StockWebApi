using StockWebApi.Models.Context;
using StockWebApi.Models.Request.Define;
using StockWebApi.Models.Request.User;

namespace StockWebApi.Repository
{
    public class UserRepository
    {
        private readonly UserContext m_userContext;

        public UserRepository(UserContext userContext) 
        {
            m_userContext = userContext;
        }

        public CreateUserStatus CreateUser(ReqCreateUser data)
        {
            var exist = (from userData in m_userContext.UserBaseInfoData
                         where userData.Account == data.Account
                         select userData).SingleOrDefault();

            if (exist == null)
            {
                return CreateUserStatus.ExistUsers;
            }

            if (string.IsNullOrEmpty(data.UserName) || string.IsNullOrEmpty(data.Account))
            {
                return CreateUserStatus.DataFail;
            }



            return CreateUserStatus.Success;
        }
    }
}
