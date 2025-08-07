using StockWebApi.Models.Request.Define;
using StockWebApi.Models.Request.User;
using StockWebApi.Repository;

namespace StockWebApi.Services
{
    public class UserService
    {
        private readonly UserRepository m_userRepository;

        public UserService(UserRepository userRepository)
        {
            m_userRepository = userRepository;
        }

        public async Task<CreateUserStatus> CreateUser(ReqCreateUser createUserData)
        {
            return await m_userRepository.CreateUser(createUserData);
        }

        public async Task<UpdateUserStatus> UpdateUser(ReqUpdateUser updateUserData)
        {
            return await m_userRepository.UpdateUser(updateUserData);
        }
    }
}
