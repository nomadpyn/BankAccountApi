#region Using
using BankAccountApi.Models;
using BankAccountApi.Utils.Helpers;
#endregion

namespace BankAccountApi.Utils
{
    #region Public Static Class CheckValue 

    /// <summary>
    /// Вспомогательный класс для валидации и проверки данных
    /// </summary>
    public static class CheckValue
    {
        #region Public Methods

        /// <summary>
        /// Возвращает true, если новый объект BankAccount соответсвует требованиям по созданию
        /// </summary>
        /// <param name="bankAccount"></param>
        /// <returns></returns>
        public static bool CheckNewBankAccount(BankAccount bankAccount)
        {
            if (bankAccount == null) { return false; }

            if (bankAccount.AccountNumber <= 0) { return false; }

            if (bankAccount.Amount < 0) { return false; }

            return true;
        }

        /// <summary>
        /// Возвращает true, если объект BankAccount пустой
        /// </summary>
        /// <param name="bankAccount"></param>
        /// <returns></returns>
        public static bool CheckEmptyBankAccount(BankAccount bankAccount)
        {
            if (bankAccount == null) { return true; }

            if (bankAccount.Id == 0 && bankAccount.AccountNumber == 0 && bankAccount.Amount == 0) { return true; }

            return false;
        }

        /// <summary>
        /// Возвращает true, если объект TransactionModel соответствует требованиям
        /// </summary>
        /// <param name="transactionModel"></param>
        /// <returns></returns>
        public static bool ValidateTransactionModel(TransactionModel transactionModel)
        {
            if (transactionModel == null)
            {
                return false;
            }

            if (!ValidateTransactionModelSign(transactionModel.TransactionSign))
            {
                return false;
            }

            if (!ValidateAccountNumber(transactionModel.BankAccountId))
            {
                return false;
            }

            if (transactionModel.TransactionSum <= 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Возвращает true, если number больше 0
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool ValidateAccountNumber(int number)
        {
            if (number <= 0) { return false; }
            return true;
        }

        /// <summary>
        /// Возвращает true, если transactionModelSign находится в списке признаков транзакции
        /// </summary>
        /// <param name="transactionModelSign"></param>
        /// <returns></returns>
        public static bool ValidateTransactionModelSign(string? transactionModelSign)
        {
            transactionModelSign = transactionModelSign ?? string.Empty;

            switch (transactionModelSign.ToLower())
            {
                case TransactionModelValue.Income:
                    {
                        return true;
                    }
                case TransactionModelValue.Expense:
                    {
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        /// <summary>
        /// Возвращает true, если объект BankTransaction пустой
        /// </summary>
        /// <param name="bankTransaction"></param>
        /// <returns></returns>
        public static bool CheckEmptyBankTransaction(BankTransaction bankTransaction)
        {
            if (bankTransaction == null)
                return true;

            if (bankTransaction.BankAccount == null || bankTransaction.TransactionSign == null)
                return true;


            return false;
        }

        /// <summary>
        /// Возвращает true, если результат расчет больше или равен 0
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool CheckTransactionResult(decimal result)
        {
            if (result < 0)
                return false;
            return true;

        }
        #endregion
    }
    #endregion
}
