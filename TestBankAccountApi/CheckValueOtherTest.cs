#region Using
using BankAccountApi.Utils;
#endregion

namespace TestBankAccountApi
{
    #region Public Class CheckValueOtherTest

    /// <summary>
    /// Тест на остальные методы CheckValue
    /// </summary>
    public class CheckValueOtherTest
    {
        #region Public Methods

        /// <summary>
        /// Тест на корректный номер банковского счета 
        /// </summary>
        [Fact]
        public void TestCorrectAccountNumber()
        {
            Assert.True(CheckValue.ValidateAccountNumber(1));
        }

        /// <summary>
        /// Тест на null номер банковского счета 
        /// </summary>
        [Fact]
        public void TestNullAccountNumber()
        {
            Assert.False(CheckValue.ValidateAccountNumber(0));
        }

        /// <summary>
        /// Тест на некорректный номер банковского счета 
        /// </summary>
        [Fact]
        public void TestInCorrectAccountNumber()
        {
            Assert.False(CheckValue.ValidateAccountNumber(-1));
        }

        /// <summary>
        /// Тест на корректный признак транзакции в lowercase
        /// </summary>
        [Fact]
        public void TestCorrectTransactionSignIncome1()
        {
            Assert.True(CheckValue.ValidateTransactionModelSign("income"));
        }

        /// <summary>
        /// Тест на корректный признак транзакции в uppercase
        /// </summary>
        [Fact]
        public void TestCorrectTransactionSignIncome2()
        {
            Assert.True(CheckValue.ValidateTransactionModelSign("INCOME"));
        }

        /// <summary>
        /// Тест на корректный признак транзакции в произвольном написании
        /// </summary>
        [Fact]
        public void TestCorrectTransactionSignIncome3()
        {
            Assert.True(CheckValue.ValidateTransactionModelSign("inCOme"));
        }

        /// <summary>
        /// Тест на корректный признак транзакции в lowercase
        /// </summary>
        [Fact]
        public void TestCorrectTransactionSignExpense1()
        {
            Assert.True(CheckValue.ValidateTransactionModelSign("expense"));
        }

        /// <summary>
        /// Тест на корректный признак транзакции в uppercase
        /// </summary>
        [Fact]
        public void TestCorrectTransactionSignExpense2()
        {
            Assert.True(CheckValue.ValidateTransactionModelSign("Expense"));
        }

        /// <summary>
        /// Тест на корректный признак транзакции в произвольном написании
        /// </summary>
        [Fact]
        public void TestCorrectTransactionSignExpense3()
        {
            Assert.True(CheckValue.ValidateTransactionModelSign("eXpENse"));
        }

        /// <summary>
        /// Тест на некорректный признак транзакции в lowercase
        /// </summary>
        [Fact]
        public void TestInCorrectTransactionSign1()
        {
            Assert.False(CheckValue.ValidateTransactionModelSign("hello"));
        }

        /// <summary>
        /// Тест на некорректный признак транзакции в uppercase
        /// </summary>
        [Fact]
        public void TestInCorrectTransactionSign2()
        {
            Assert.False(CheckValue.ValidateTransactionModelSign("HELLO"));
        }

        /// <summary>
        /// Тест на некорректный признак транзакции в произвольном написании
        /// </summary>
        [Fact]
        public void TestInCorrectTransactionSign3()
        {
            Assert.False(CheckValue.ValidateTransactionModelSign("heLlO"));
        }

        /// <summary>
        /// Тест на корректный результат расчета при транзакции
        /// </summary>
        [Fact]
        public void TestCorrectTransactionResult()
        {
            Assert.True(CheckValue.CheckTransactionResult((decimal)0.1));
        }

        /// <summary>
        /// Тест на нулевой результат расчета при транзакции
        /// </summary>
        [Fact]
        public void TestNullTransactionResult()
        {
            Assert.True(CheckValue.CheckTransactionResult(0));
        }

        /// <summary>
        /// Тест на некорректный результат расчета при транзакции
        /// </summary>
        [Fact]
        public void TestIncCorrectTransactionResult()
        {
            Assert.False(CheckValue.CheckTransactionResult((decimal)-0.1));
        }
        #endregion
    }
    #endregion
}
