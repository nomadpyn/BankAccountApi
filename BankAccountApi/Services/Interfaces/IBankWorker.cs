#region Using
using BankAccountApi.Models;
using BankAccountApi.Models.Dto;
#endregion

namespace BankAccountApi.Services.Interfaces
{
    #region Public Interface IBankWorker

    /// <summary>
    /// Интерфейс, который должен реализовать класс для работы с репозиторием 
    /// </summary>
    public interface IBankWorker
    {
        #region Public Methods

        /// <summary>
        /// Получаем банковский аккаунт по номеру счета
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        Task<BankAccount> GetBankAccountByAccountNumber (int accountNumber);

        /// <summary>
        /// Создание нового банковского аккаунта
        /// </summary>
        /// <param name="bankAccount"></param>
        /// <returns></returns>
        Task<BankAccount> CreateBankAccount(BankAccount bankAccount);

        /// <summary>
        /// Создание новой банковской транзакции по транзакционной модели
        /// </summary>
        /// <param name="transactionModel"></param>
        /// <returns></returns>
        Task<BankTransaction> CreateBankTransaction(TransactionModel transactionModel);

        /// <summary>
        /// Получение списка всех транзакции
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<BankTransactionDto>> GetAllTransactions();

        /// <summary>
        /// Получение списка транзакции по номеру счета
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        Task<IEnumerable<BankTransactionDto>> GetTransactionsById( int accountNumber);

        /// <summary>
        /// Получение списка всех транзакции постранично
        /// </summary>
        /// <param name="pageParameters"></param>
        /// <returns></returns>
        Task<IEnumerable<BankTransactionDto>> GetAllTransactionsByPage(PageParameters pageParameters);

        /// <summary>
        /// Получение списка транзакции по номеру счета постранично
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="pageParameters"></param>
        /// <returns></returns>
        Task<IEnumerable<BankTransactionDto>> GetTransactionsByIdByPage(int accountNumber, PageParameters pageParameters);
        #endregion
    }
    #endregion
}
