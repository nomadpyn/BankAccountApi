#region Using
using BankAccountApi.Models;
#endregion

namespace TestBankAccountApi.Factorys
{
    #region Internal Class BankAccountFactory

    /// <summary>
    /// Фабрика для создание разных вариантов BankAccount
    /// </summary>
    internal class BankAccountFactory
    {
        #region Public Methods

        /// <summary>
        /// Возвращает корректный банковский счет
        /// </summary>
        /// <returns></returns>
        public BankAccount CreateCorrectBankAccount()
        {
            return new BankAccount()
            {
                Id = 1,
                AccountNumber = 1,
                Amount = 1,
            };
        }

        /// <summary>
        /// Возвращает null объект
        /// </summary>
        /// <returns></returns>
        public BankAccount CreateNullBankAccount()
        {
            return null;
        }

        /// <summary>
        /// Возвращает пустой объект
        /// </summary>
        /// <returns></returns>
        public BankAccount CreateEmptyBankAccount()
        {
            return new BankAccount();
        }

        /// <summary>
        /// Возвращает банковский счет с некорректным номером счета
        /// </summary>
        /// <returns></returns>
        public BankAccount CreateIncorrectAccountNumberBankAccount()
        {
            return new BankAccount()
            {
                Id = 1,
                AccountNumber = -1,
                Amount = 1,
            };
        }

        /// <summary>
        /// Возвращает банковский счет с некорректной суммой на счету
        /// </summary>
        /// <returns></returns>
        public BankAccount CreateIncorrectAmountBankAccount()
        {
            return new BankAccount()
            {
                Id = 1,
                AccountNumber = 1,
                Amount = -1,
            };
        }

        /// <summary>
        /// Возвращает банковский счет с некорректными данными
        /// </summary>
        /// <returns></returns>
        public BankAccount CreateIncorrectAllBankAccount()
        {
            return new BankAccount()
            {
                Id = 1,
                AccountNumber = 0,
                Amount = -1,
            };
        }
        #endregion
    }
    #endregion
}
