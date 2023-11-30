using AutoMapper;
using System.Reflection;

namespace TrendBankServer
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<TrendBankServer.Models.User, TrendBankServer.Models.DataTransferObjects.UserDto>();
            CreateMap<TrendBankServer.Models.Card, TrendBankServer.Models.DataTransferObjects.CardDto>();
            CreateMap<TrendBankServer.Models.Transaction, TrendBankServer.Models.DataTransferObjects.TransactionDto>();
        }
    }
}
