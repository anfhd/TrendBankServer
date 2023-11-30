using AutoMapper;
using System.Reflection;

namespace TrendBankServer
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.User, Models.DataTransferObjects.UserDto>();
            CreateMap<Models.Card, Models.DataTransferObjects.CardDto>();
            CreateMap<Models.Transaction, Models.DataTransferObjects.TransactionDto>();

            CreateMap<Models.DataTransferObjects.UserForCreationDto, Models.User>();
        }
    }
}
