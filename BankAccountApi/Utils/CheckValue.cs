using BankAccountApi.Models;
using BankAccountApi.Utils.Helpers;

namespace BankAccountApi.Utils
{
    public static class CheckValue
    {
        public static bool CheckNewBankAccount(BankAccount bankAccount)
        {
            if (bankAccount == null) { return false; }

            if (bankAccount.AccountNumber <= 0) { return false; }

            if (bankAccount.Amount < 0) { return false; }

            return true;
        }
        public static bool CheckEmptyBankAccount(BankAccount bankAccount)
        {
            if (bankAccount == null) { return true; }

            if (bankAccount.Id == 0 && bankAccount.AccountNumber == 0 && bankAccount.Amount == 0) { return true; }

            return false;
        }
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
        public static bool ValidateAccountNumber(int number)
        {
            if (number <= 0) { return false; }
            return true;
        }
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
        public static bool CheckEmptyBankTransaction(BankTransaction bankTransaction)
        {
            if (bankTransaction == null)
                return true;

            if (bankTransaction.BankAccount == null || bankTransaction.TransactionSign == null)
                return true;


            return false;
        }
        public static bool CheckTransactionResult(decimal result)
        {
            if (result < 0)
                return false;
            return true;

        }
    }
}
