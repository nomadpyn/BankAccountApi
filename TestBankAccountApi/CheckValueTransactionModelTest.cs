#region Using
using BankAccountApi.Utils;
using TestBankAccountApi.Factorys;
#endregion

namespace TestBankAccountApi
{
    #region Public Class CheckValueTransactionModelTest

    /// <summary>
    /// Класс для тестирование проверок TransactionModel
    /// </summary>
    public class CheckValueTransactionModelTest
    {
        #region Private Fields

        /// <summary>
        /// Фабрика для создания экземпляров TransactionModel
        /// </summary>
        private TransactionModelFactory factory = new();
        #endregion

        #region Public Methods

        /// <summary>
        /// Тест ValidateTransactionModel при корректной транзакции на пополнение
        /// </summary>
        [Fact]
        public void TestCorrectTransactionModelIncome()
        {
            var transactionModel = factory.CreateCorrectTransactionModelIncome();

            Assert.True(CheckValue.ValidateTransactionModel(transactionModel));
        }

        /// <summary>
        /// Тест ValidateTransactionModel при корректной транзакции на снятие
        /// </summary>
        [Fact]
        public void TestCorrectTransactionModelExpense()
        {
            var transactionModel = factory.CreateCorrectTransactionModelExpense();

            Assert.True(CheckValue.ValidateTransactionModel(transactionModel));
        }

        /// <summary>
        /// Тест ValidateTransactionModel при транзакции с некорректным признаком
        /// </summary>
        [Fact]
        public void TestInCorrectSignTransactionModel()
        {
            var transactionModel = factory.CreateInCorrectSignTransactionModel();

            Assert.False(CheckValue.ValidateTransactionModel(transactionModel));
        }

        /// <summary>
        /// Тест ValidateTransactionModel при транзакции с некорректными данными
        /// </summary>
        [Fact]
        public void TestInCorrectAllTransactionModel()
        {
            var transactionModel = factory.CreateInCorrectAllTransactionModel();

            Assert.False(CheckValue.ValidateTransactionModel(transactionModel));
        }

        /// <summary>
        /// Тест ValidateTransactionModel при null транзакции
        /// </summary>
        [Fact]
        public void TestNullTransactionModel()
        {
            var transactionModel = factory.CreateNullTransactionModel();

            Assert.False(CheckValue.ValidateTransactionModel(transactionModel));
        }

        /// <summary>
        /// Тест ValidateTransactionModel при пустой транзакции
        /// </summary>
        [Fact]
        public void TestEmptyTransactionModel()
        {
            var transactionModel = factory.CreateEmptyTransactionModel();

            Assert.False(CheckValue.ValidateTransactionModel(transactionModel));
        }

        /// <summary>
        /// Тест ValidateTransactionModel при некорректной транзакции на пополнение, некорректная сумма
        /// </summary>
        [Fact]
        public void TestInCorrectSumTransactionModelIncome()
        {
            var transactionModel = factory.CreateInCorrectSumTransactionModelIncome();

            Assert.False(CheckValue.ValidateTransactionModel(transactionModel));
        }

        /// <summary>
        /// Тест ValidateTransactionModel при некорректной транзакции на пополнение, некорректный номер счета
        /// </summary>
        [Fact]
        public void TestInCorrectIdTransactionModelIncome()
        {
            var transactionModel = factory.CreateInCorrectIdTransactionModelIncome();

            Assert.False(CheckValue.ValidateTransactionModel(transactionModel));
        }

        /// <summary>
        /// Тест ValidateTransactionModel при некорректной транзакции на пополнение, некорректные данные
        /// </summary>
        [Fact]
        public void TestInCorrectAllTransactionModelIncome()
        {
            var transactionModel = factory.CreateInCorrectAllTransactionModelIncome();

            Assert.False(CheckValue.ValidateTransactionModel(transactionModel));
        }

        /// <summary>
        /// Тест ValidateTransactionModel при некорректной транзакции на снятие, некорректная сумма
        /// </summary>
        [Fact]
        public void TestInCorrectSumTransactionModelExpense()
        {
            var transactionModel = factory.CreateInCorrectSumTransactionModelExpense();

            Assert.False(CheckValue.ValidateTransactionModel(transactionModel));
        }

        /// <summary>
        /// Тест ValidateTransactionModel при некорректной транзакции на снятие, некорректный номер счета
        /// </summary>
        [Fact]
        public void TestInCorrectIdTransactionModelExpense()
        {
            var transactionModel = factory.CreateInCorrectIdTransactionModelExpense();

            Assert.False(CheckValue.ValidateTransactionModel(transactionModel));
        }

        /// <summary>
        /// Тест ValidateTransactionModel при некорректной транзакции на снятие, некорректные данные
        /// </summary>
        [Fact]
        public void TestInCorrectAllTransactionModelExpense()
        {
            var transactionModel = factory.CreateInCorrectAllTransactionModelExpense();

            Assert.False(CheckValue.ValidateTransactionModel(transactionModel));
        }
        #endregion
    }
    #endregion
}
