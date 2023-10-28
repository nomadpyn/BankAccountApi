#region Using
using BankAccountApi.Utils;
using TestBankAccountApi.Factorys;
#endregion

namespace TestBankAccountApi
{
    #region Public Class CheckValueBankAccountTest

    /// <summary>
    /// Класс для тестирование проверок bankaccount
    /// </summary>
    public class CheckValueBankAccountTest
    {
        #region Private Fields
        /// <summary>
        /// Фабрика для создания экземпляров bankaccount
        /// </summary>
        private BankAccountFactory? factory = new();
        #endregion

        #region Public Methods

        /// <summary>
        /// Тест CheckNewBankAccount на корректном bankaccount
        /// </summary>
        [Fact]
        public void TestCheckNewBankAccountCorrect()
        {
            var account = factory.CreateCorrectBankAccount();

            Assert.True(CheckValue.CheckNewBankAccount(account));
        }

        /// <summary>
        /// Тест CheckNewBankAccount на null bankaccount
        /// </summary>
        [Fact]
        public void TestCheckNewBankAccountNull()
        {
            var account = factory.CreateNullBankAccount();

            Assert.False(CheckValue.CheckNewBankAccount(account));
        }

        /// <summary>
        /// Тест CheckNewBankAccount на пустом bankaccount
        /// </summary>
        [Fact]
        public void TestCheckNewBankAccountEmpty()
        {
            var account = factory.CreateEmptyBankAccount();

            Assert.False(CheckValue.CheckNewBankAccount(account));
        }

        /// <summary>
        /// Тест CheckNewBankAccount на bankaccount с некорректной суммой на счету
        /// </summary>
        [Fact]
        public void TestCheckNewBankAccountIncorrectAmount()
        {
            var account = factory.CreateIncorrectAmountBankAccount();

            Assert.False(CheckValue.CheckNewBankAccount(account));
        }

        /// <summary>
        /// Тест CheckNewBankAccount на bankaccount с некорректным номером счета
        /// </summary>
        [Fact]
        public void TestCheckNewBankAccountIncorrectAccountNumber()
        {
            var account = factory.CreateIncorrectAccountNumberBankAccount();

            Assert.False(CheckValue.CheckNewBankAccount(account));
        }

        /// <summary>
        /// Тест CheckNewBankAccount на bankaccount с некорректной суммой на счету и некорректным номером счета
        /// </summary>
        [Fact]
        public void TestCheckNewBankAccountIncorrectAll()
        {
            var account = factory.CreateIncorrectAllBankAccount();

            Assert.False(CheckValue.CheckNewBankAccount(account));
        }

        /// <summary>
        /// Тест CheckEmptyBankAccount на корректном bankaccount
        /// </summary>
        [Fact]
        public void TestCheckEmptyBankAccountCorrect()
        {
            var account = factory.CreateCorrectBankAccount();

            Assert.False(CheckValue.CheckEmptyBankAccount(account));
        }

        /// <summary>
        /// Тест CheckEmptyBankAccount на null bankaccount
        /// </summary>
        [Fact]
        public void TestCheckEmptyBankAccountNull()
        {
            var account = factory.CreateNullBankAccount();

            Assert.True(CheckValue.CheckEmptyBankAccount(account));
        }

        /// <summary>
        /// Тест CheckEmptyBankAccount на пустом bankaccount
        /// </summary>
        [Fact]
        public void TestCheckEmptyBankAccountEmpty()
        {
            var account = factory.CreateEmptyBankAccount();

            Assert.True(CheckValue.CheckEmptyBankAccount(account));
        }

        /// <summary>
        /// Тест CheckEmptyBankAccount на bankaccount с некорректной суммой на счету
        /// </summary>
        [Fact]
        public void TestCheckEmptyBankAccountIncorrectAmount()
        {
            var account = factory.CreateIncorrectAmountBankAccount();

            Assert.False(CheckValue.CheckEmptyBankAccount(account));
        }

        /// <summary>
        /// Тест CheckEmptyBankAccount на bankaccount с некорректным номером счета
        /// </summary>
        [Fact]
        public void TestCheckEmptyBankAccountIncorrectAccountNumber()
        {
            var account = factory.CreateIncorrectAccountNumberBankAccount();

            Assert.False(CheckValue.CheckEmptyBankAccount(account));
        }

        /// <summary>
        /// Тест CheckEmptyBankAccount на bankaccount с некорректной суммой на счету и некорректным номером счета
        /// </summary>
        [Fact]
        public void TestCheckEmptyBankAccountIncorrectAll()
        {
            var account = factory.CreateIncorrectAllBankAccount();

            Assert.False(CheckValue.CheckEmptyBankAccount(account));
        }
        #endregion
    }
    #endregion
}