#region Using
using BankAccountApi.Models;
#endregion

namespace TestBankAccountApi.Factorys
{
    #region Internal Class TransactionModelFactory

    /// <summary>
    /// Фабрика для создание разных вариантов TransactionModel
    /// </summary>
    internal class TransactionModelFactory
    {
        #region Public Methods

        /// <summary>
        /// Возвращает корректную транзакцию на пополнение
        /// </summary>
        /// <returns></returns>
        public TransactionModel CreateCorrectTransactionModelIncome()
        {
            return new TransactionModel()
            {
                TransactionSign = "income",
                TransactionSum = 1,
                BankAccountId = 1
            };
        }

        /// <summary>
        /// Возвращает транзакцию с некорректным признаком
        /// </summary>
        /// <returns></returns>
        public TransactionModel CreateInCorrectSignTransactionModel()
        {
            return new TransactionModel()
            {
                TransactionSign = "nothing",
                TransactionSum = 1,
                BankAccountId = 1
            };
        }

        /// <summary>
        /// Возвращает некорректную транзакцию
        /// </summary>
        /// <returns></returns>
        public TransactionModel CreateInCorrectAllTransactionModel()
        {
            return new TransactionModel()
            {
                TransactionSign = "nothing",
                TransactionSum = 0,
                BankAccountId = 0
            };
        }

        /// <summary>
        /// Возвращает корректную транзакцию на снятие
        /// </summary>
        /// <returns></returns>
        public TransactionModel CreateCorrectTransactionModelExpense()
        {
            return new TransactionModel()
            {
                TransactionSign = "expense",
                TransactionSum = 1,
                BankAccountId = 1
            };
        }

        /// <summary>
        /// Возвращает null транзакцию
        /// </summary>
        /// <returns></returns>
        public TransactionModel CreateNullTransactionModel()
        {
            return null;
        }

        /// <summary>
        /// Возвращает пустую транзакцию
        /// </summary>
        /// <returns></returns>
        public TransactionModel CreateEmptyTransactionModel()
        {
            return new TransactionModel();
        }

        /// <summary>
        /// Возвращает транзакцию на пополнение с некорректной суммой
        /// </summary>
        /// <returns></returns>
        public TransactionModel CreateInCorrectSumTransactionModelIncome()
        {
            return new TransactionModel()
            {
                TransactionSign = "income",
                TransactionSum = 0,
                BankAccountId = 1
            };
        }

        /// <summary>
        /// Возвращает транзакцию на пополнение с некорректным банковским счетом
        /// </summary>
        /// <returns></returns>
        public TransactionModel CreateInCorrectIdTransactionModelIncome()
        {
            return new TransactionModel()
            {
                TransactionSign = "income",
                TransactionSum = 1,
                BankAccountId = 0
            };
        }

        /// <summary>
        /// Возвращает транзакцию на пополнение с некорректной суммой и некорректным банковским счетом
        /// </summary>
        /// <returns></returns>
        public TransactionModel CreateInCorrectAllTransactionModelIncome()
        {
            return new TransactionModel()
            {
                TransactionSign = "income",
                TransactionSum = 0,
                BankAccountId = 0
            };
        }

        /// <summary>
        /// Возвращает транзакцию на снятие с некорректной суммой
        /// </summary>
        /// <returns></returns>
        public TransactionModel CreateInCorrectSumTransactionModelExpense()
        {
            return new TransactionModel()
            {
                TransactionSign = "Expense",
                TransactionSum = 0,
                BankAccountId = 1
            };
        }

        /// <summary>
        /// Возвращает транзакцию на снятие с некорректным банковским счетом
        /// </summary>
        /// <returns></returns>
        public TransactionModel CreateInCorrectIdTransactionModelExpense()
        {
            return new TransactionModel()
            {
                TransactionSign = "Expense",
                TransactionSum = 1,
                BankAccountId = 0
            };
        }

        /// <summary>
        /// Возвращает транзакцию на снятие с некорректной суммой и некорректным банковским счетом
        /// </summary>
        /// <returns></returns>
        public TransactionModel CreateInCorrectAllTransactionModelExpense()
        {
            return new TransactionModel()
            {
                TransactionSign = "Expense",
                TransactionSum = 0,
                BankAccountId = 0
            };
        }
        #endregion
    }
    #endregion
}
