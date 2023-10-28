
namespace BankAccountApi.Models
{
    #region Public Class BankAccount

    /// <summary>
    /// Модель для банковского счета
    /// </summary>
    public class BankAccount
    {
        #region Public Fields

        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public int Id { get; set; }               
        
        /// <summary>
        /// Номер счета
        /// </summary>
        public int AccountNumber { get; set; }

        /// <summary>
        /// Сумма на счету
        /// </summary>
        public decimal Amount { get; set; }
        #endregion
    }
    #endregion
}
