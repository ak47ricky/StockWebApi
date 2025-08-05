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

        public CreateUserStatus CreateUser(ReqCreateUser createUserData)
        {
            return m_userRepository.CreateUser(createUserData);
        }
    }
}
