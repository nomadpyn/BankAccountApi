
namespace BankAccountApi.Models
{
    #region Public Class BankTransaction

    /// <summary>
    /// Модель для банковской транзакции
    /// </summary>
    public class BankTransaction
    {
        #region Public Fields

        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата транзакции 
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
        /// Баланс на счету после транзакции
        /// </summary>
        public decimal BalanceAfterTransaction { get; set; }

        /// <summary>
        /// Счет на котором провелась транзакция
        /// </summary>
        public BankAccount? BankAccount { get; set; }

        #endregion
    }
    #endregion
}
