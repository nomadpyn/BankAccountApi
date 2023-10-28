#region Using
using BankAccountApi.Models;
#endregion

namespace BankAccountApi.Services.Interfaces
{
    #region Public Interface IBankRepository

    /// <summary>
    /// Интерфейс, который должен реализовать объект BankRepository
    /// </summary>
    public interface IBankRepository
    {
        #region Public Methods

        /// <summary>
        /// Получаем банковский аккаунт по номеру счета
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        Task<BankAccount> GetBankAccount(int accountNumber);

        /// <summary>
        /// Создаем новый банковский счет
        /// </summary>
        /// <param name="bankAccount"></param>
        /// <returns></returns>
        Task<BankAccount> CreateNewBankAccount(BankAccount bankAccount);

        /// <summary>
        /// Создаем новую транзакцию
        /// </summary>
        /// <param name="bankTransaction"></param>
        /// <returns></returns>
        Task<BankTransaction> CreateTransaction(BankTransaction bankTransaction);

        /// <summary>
        /// Получаем все транзакции
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<BankTransaction>> GetAllTransaction();

        /// <summary>
        /// Получаем транзакции по номеру счета
        /// </summary>
        /// <param name="bankAccount"></param>
        /// <returns></returns>
        Task<IEnumerable<BankTransaction>> GetTransactionsByAccount(BankAccount bankAccount);

        /// <summary>
        /// Получаем все транзакции постранично
        /// </summary>
        /// <param name="pageParameters"></param>
        /// <returns></returns>
        Task<IEnumerable<BankTransaction>> GetAllTransactionByPage(PageParameters pageParameters);

        /// <summary>
        /// Получаем транзакции по номеру счета постранично
        /// </summary>
        /// <param name="bankAccount"></param>
        /// <param name="pageParameters"></param>
        /// <returns></returns>
        Task<IEnumerable<BankTransaction>> GetTransactionsByAccountByPage(BankAccount bankAccount,PageParameters pageParameters);
        #endregion
    }
    #endregion
}
