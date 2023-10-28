namespace BankAccountApi.Models.Dto
{
    #region Public Class BankTransactionDto

    /// <summary>
    /// ДТО для банковской транзакции
    /// </summary>
    public class BankTransactionDto
    {
        #region Public Fields

        /// <summary>
        /// Номер счета по которой произвелась транзакция
        /// </summary>
        public int AccountNumber { get; set; }

        /// <summary>
        /// Время проведения транзакции
        /// </summary>
        public DateTimeOffset TransactionTime { get; set; }

        /// <summary>
        /// Признак транзакции
        /// </summary>
        public string? TransactionSign { get; set; }

        /// <summary>
        /// Сумма транзакции
        /// </summary>
        public decimal TransactionSum { get; set; }

        /// <summary>
        /// Сумма на счету после проведения транзакции
        /// </summary>
        public decimal BalanceAfterTransaction { get; set; }
        #endregion
    }
    #endregion
}
