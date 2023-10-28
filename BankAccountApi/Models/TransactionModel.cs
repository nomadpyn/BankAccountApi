namespace BankAccountApi.Models
{
    #region Public Class TransactionModel

    /// <summary>
    /// Класс для транзакционной модели
    /// </summary>
    public class TransactionModel
    {
        #region Public Fields

        /// <summary>
        /// Признак транзакции (поступление, снятие)
        /// </summary>
        public string? TransactionSign { get; set; }

        /// <summary>
        /// Номер банковского счета
        /// </summary>
        public int BankAccountId { get; set; }

        /// <summary>
        /// Сумма транзакции
        /// </summary>
        public decimal TransactionSum {  get; set; }
        #endregion
    }
    #endregion
}
