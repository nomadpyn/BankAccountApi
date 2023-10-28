namespace BankAccountApi.Utils.Helpers
{
    #region Public Static Class TransactionModelValue

    /// <summary>
    /// Хранит значения признаков транзакции
    /// </summary>
    public static class TransactionModelValue
    {
        #region Public Fields

        /// <summary>
        /// Пополнение счета 
        /// </summary>
        public const string Income = "income";

        /// <summary>
        /// Снятие со счета
        /// </summary>
        public const string Expense = "expense";
        #endregion
    }
    #endregion
}
