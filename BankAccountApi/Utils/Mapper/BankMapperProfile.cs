#region Using
using AutoMapper;
using BankAccountApi.Models;
using BankAccountApi.Models.Dto;
#endregion

namespace BankAccountApi.Utils.Mapper
{
    #region Public Class BankMapperProfile

    /// <summary>
    /// Профиль для AutoMapper
    /// </summary>
    public class BankMapperProfile : Profile
    {
        #region Constructor

        /// <summary>
        /// Map из BankTransaction в BankTransactionDto
        /// </summary>
        public BankMapperProfile()
        {

            CreateMap<BankTransaction, BankTransactionDto>()
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.BankAccount.AccountNumber))
                .ForMember(dest => dest.TransactionTime, opt => opt.MapFrom(src => src.TransactionTime))
                .ForMember(dest => dest.TransactionSign, opt => opt.MapFrom(src => src.TransactionSign))
                .ForMember(dest => dest.TransactionSum, opt => opt.MapFrom(src => src.TransactionSum))
                .ForMember(dest => dest.BalanceAfterTransaction, opt => opt.MapFrom(src => src.BalanceAfterTransaction));
        }
        #endregion
    }
#endregion
}
