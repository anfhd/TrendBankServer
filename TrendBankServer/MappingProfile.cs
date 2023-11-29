using AutoMapper;
using System.Reflection;

namespace TrendBankServer
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<TrendBankServer.Models.User, TrendBankServer.Models.DataTransferObjects.UserDto>();
        }
    }
}
