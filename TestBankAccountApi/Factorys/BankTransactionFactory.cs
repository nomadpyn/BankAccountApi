#region Using
using BankAccountApi.Models;
#endregion

namespace TestBankAccountApi.Factorys
{
    #region Internal Class BankTransactionFactory

    /// <summary>
    /// Фабрика для создание разных вариантов BankTransaction
    /// </summary>
    internal class BankTransactionFactory
    {
        #region Public Methods

        /// <summary>
        /// Возвращает корректную транзакцию
        /// </summary>
        /// <returns></returns>
        public BankTransaction CreateCorrectTransaction()
        {
            return new BankTransaction()
            {
                Id = 1,
                TransactionTime = DateTimeOffset.Now,
                TransactionSign = "income",
                TransactionSum = 1,
                BalanceAfterTransaction = 1,
                BankAccount = new BankAccount()
                {
                    Id = 1,
                    AccountNumber = 1,
                    Amount = 1
                }
            };
        }

        /// <summary>
        /// Возвращает null транзакцию
        /// </summary>
        /// <returns></returns>
        public BankTransaction CreateNullTransaction()
        {
            return null;
        }

        /// <summary>
        /// Возвращает пустую транзакцию
        /// </summary>
        /// <returns></returns>
        public BankTransaction CreateEmptyTransaction()
        {
            return new();
        }

        /// <summary>
        /// Возвращает транзакцию с null банковским аккаунтом
        /// </summary>
        /// <returns></returns>
        public BankTransaction CreateNullBankAccountTransaction()
        {
            return new BankTransaction()
            {
                Id = 1,
                TransactionTime = DateTimeOffset.Now,
                TransactionSign = "income",
                TransactionSum = 1,
                BalanceAfterTransaction = 1,
                BankAccount = null
            };
        }

        /// <summary>
        /// Возвращает транзакцию с null признаком транзакции
        /// </summary>
        /// <returns></returns>
        public BankTransaction CreateNullSignTransaction()
        {
            return new BankTransaction()
            {
                Id = 1,
                TransactionTime = DateTimeOffset.Now,
                TransactionSign = null,
                TransactionSum = 1,
                BalanceAfterTransaction = 1,
                BankAccount = new BankAccount()
                {
                    Id = 1,
                    AccountNumber = 1,
                    Amount = 1
                }
            };
        }

        /// <summary>
        /// Возвращает транзакцию с null банковским аккаунтом и null признаком транзакции
        /// </summary>
        /// <returns></returns>
        public BankTransaction CreateNullSignNullAccountTransaction()
        {
            return new BankTransaction()
            {
                Id = 1,
                TransactionTime = DateTimeOffset.Now,
                TransactionSign = null,
                TransactionSum = 1,
                BalanceAfterTransaction = 1,
                BankAccount = null
            };
        }
        #endregion
    }
    #endregion
}
