using AutoMapper;
using StockWebApi.Models.UserData;

namespace StockWebApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserBaseInfoData, UserBaseInfoDataDTO>();
        }
    }
}
