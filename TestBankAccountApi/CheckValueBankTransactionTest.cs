#region Using
using BankAccountApi.Utils;
using TestBankAccountApi.Factorys;
#endregion

namespace TestBankAccountApi
{
    #region Public Class CheckValueBankTransactionTest

    /// <summary>
    /// Класс для тестирование проверок BankTransaction
    /// </summary>
    public class CheckValueBankTransactionTest
    {
        #region Private Fields

        /// <summary>
        /// Фабрика для создания экземпляров BankTransaction
        /// </summary>
        private BankTransactionFactory factory = new();
        #endregion

        #region Public Methods

        /// <summary>
        /// Тест на CheckEmptyBankTransaction на корректном BankTransaction 
        /// </summary>
        [Fact]
        public void TestCorrectBankTransaction()
        {
            var transaction = factory.CreateCorrectTransaction();

            Assert.False(CheckValue.CheckEmptyBankTransaction(transaction));
        }

        /// <summary>
        /// Тест на CheckEmptyBankTransaction на null BankTransaction 
        /// </summary>
        [Fact]
        public void TestNullBankTransaction()
        {
            var transaction = factory.CreateNullTransaction();

            Assert.True(CheckValue.CheckEmptyBankTransaction(transaction));
        }

        /// <summary>
        /// Тест на CheckEmptyBankTransaction на пустом BankTransaction 
        /// </summary>
        [Fact]
        public void TestEmptyBankTransaction()
        {
            var transaction = factory.CreateEmptyTransaction();

            Assert.True(CheckValue.CheckEmptyBankTransaction(transaction));
        }

        /// <summary>
        /// Тест на CheckEmptyBankTransaction на BankTransaction с null TransactionSign
        /// </summary>
        [Fact]
        public void TestNullSignBankTransaction()
        {
            var transaction = factory.CreateNullSignTransaction();

            Assert.True(CheckValue.CheckEmptyBankTransaction(transaction));
        }

        /// <summary>
        /// Тест на CheckEmptyBankTransaction на BankTransaction с null BancAccount
        /// </summary>
        [Fact]
        public void TestNullAccountBankTransaction()
        {
            var transaction = factory.CreateNullBankAccountTransaction();

            Assert.True(CheckValue.CheckEmptyBankTransaction(transaction));
        }

        /// <summary>
        /// Тест на CheckEmptyBankTransaction на BankTransaction с null TransactionSign и null BancAccount
        /// </summary>
        [Fact]
        public void TestNullSignNullAccountBankTransaction()
        {
            var transaction = factory.CreateNullSignNullAccountTransaction();

            Assert.True(CheckValue.CheckEmptyBankTransaction(transaction));
        }
        #endregion
    }
    #endregion
}
