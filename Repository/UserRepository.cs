using StockWebApi.CommonFun;
using StockWebApi.Models.Context;
using StockWebApi.Models.Request.Define;
using StockWebApi.Models.Request.User;
using StockWebApi.Models.UserData;

namespace StockWebApi.Repository
{
    public class UserRepository
    {
        private readonly UserContext m_userContext;

        public UserRepository(UserContext userContext) 
        {
            m_userContext = userContext;
        }

        public async Task<CreateUserStatus> CreateUser(ReqCreateUser data)
        {
            var exist = (from userData in m_userContext.UserBaseInfoData
                         where userData.Account == data.Account
                         select userData).SingleOrDefault();

            if (exist != null)
            {
                return CreateUserStatus.ExistUsers;
            }

            if (string.IsNullOrEmpty(data.UserName) || string.IsNullOrEmpty(data.Account))
            {
                return CreateUserStatus.DataFail;
            }

            if (string.IsNullOrEmpty(data.Password) || string.IsNullOrEmpty(data.Mail))
            {
                return CreateUserStatus.DataFail;
            }

            var salt = Sha256CreateHash.GenerateSalt();

            var passwordHash = Sha256CreateHash.GetHashCode(data.Password, salt);

            UserBaseInfoData userBaseInfoData = new UserBaseInfoData()
            {
                Guid = Guid.NewGuid(),
                UserName = data.UserName,
                Account = data.Account,
                PasswordHash = passwordHash,
                PasswordSalt= salt,
                Email = data.Mail,
                Permissions = 1
            };

            await m_userContext.AddAsync(userBaseInfoData);

            await m_userContext.SaveChangesAsync();

            return CreateUserStatus.Success;
        }
    }
}
