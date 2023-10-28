using AutoMapper;
using BankAccountApi.Models;
using BankAccountApi.Models.Dto;

namespace BankAccountApi.Utils.Mapper
{
    public class BankMapperProfile : Profile
    {
        public BankMapperProfile()
        {

            CreateMap<BankTransaction, BankTransactionDto>()
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.BankAccount.AccountNumber))
                .ForMember(dest => dest.TransactionTime, opt => opt.MapFrom(src => src.TransactionTime))
                .ForMember(dest => dest.TransactionSign, opt => opt.MapFrom(src => src.TransactionSign))
                .ForMember(dest => dest.TransactionSum, opt => opt.MapFrom(src => src.TransactionSum))
                .ForMember(dest => dest.BalanceAfterTransaction, opt => opt.MapFrom(src => src.BalanceAfterTransaction));
        }
    }
}
