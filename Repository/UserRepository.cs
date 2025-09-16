using Microsoft.EntityFrameworkCore;
using StockWebApi.CommonFun;
using StockWebApi.Models.Context.User;
using StockWebApi.Models.Data.UserData;
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

        public async Task<UserBaseInfoDataDTO?> GetUserInfoDataDTO(string account)
        {
            var result = await m_userContext.UserBaseInfoData
                        .Where(a => a.Account == account)
                        .Select(a => new UserBaseInfoDataDTO
                        {
                            Account = a.Account,
                            UserId = a.Id,
                            UserName = a.UserName,
                            Permissions = a.Permissions,
                            Guid = a.Guid,
                            
                        }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<int> GetAccountDataId(string account)
        {
            var result = await m_userContext.AccountData
                        .Where(a => a.Account == account)
                        .Select(a => a.Id)
                        .FirstOrDefaultAsync();

            return result;
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

            var guidId = Guid.NewGuid();

            AccountData accountData = new AccountData()
            { 
                GuidId = guidId,

                Account = data.Account,

                UserName = data.UserName,

                Permissions = 1
            };

            UserBaseInfoData userBaseInfoData = new UserBaseInfoData()
            {
                Guid = guidId,
                UserName = data.UserName,
                Account = data.Account,
                PasswordHash = passwordHash,
                PasswordSalt= salt,
                Email = data.Mail,
                Permissions = 1,
                AccountData = accountData 
            };

            await m_userContext.AddAsync(accountData);

            await m_userContext.AddAsync(userBaseInfoData);

            await m_userContext.SaveChangesAsync();

            return CreateUserStatus.Success;
        }

        public async Task<UpdateUserStatus> UpdateUser(ReqUpdateUser updateUserData)
        {
            if (string.IsNullOrEmpty(updateUserData.Account) || string.IsNullOrEmpty(updateUserData.Password))
            {
                return UpdateUserStatus.DataFail;
            }

            var result = (from userData in m_userContext.UserBaseInfoData
                          where userData.Account == updateUserData.Account
                          select userData).FirstOrDefault();

            if (result == null)
            {
                return UpdateUserStatus.NotExistUsers;
            }

            var slat = result.PasswordSalt;

            var passwordHash = Sha256CreateHash.GetHashCode(updateUserData.Password, slat);

            if(result.PasswordHash != passwordHash)
            {
                return UpdateUserStatus.PasswordFail;
            }

            result.Email = updateUserData.Mail;

            await m_userContext.SaveChangesAsync();

            return UpdateUserStatus.Success;
        }
    }
}
