#region Using
using Microsoft.EntityFrameworkCore;
using BankAccountApi.Data;
using BankAccountApi.Models;
using BankAccountApi.Services.Interfaces;
#endregion

namespace BankAccountApi.Services
{
    #region Public Class BankRepository

    /// <summary>
    /// Репозитори для работы с БД по BankContext
    /// </summary>
    public class BankRepository : IBankRepository
    {
        #region Private Fields

        /// <summary>
        /// Контекст для подлючения к БД
        /// </summary>
        private readonly BankContext _dbContext;
        #endregion

        #region Constructor
        public BankRepository(BankContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Получаем объект из БД по номеру счета
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public async Task<BankAccount> GetBankAccount(int accountNumber)
        {
            BankAccount? account = null;
            try
            {
                 account = await _dbContext.BankAccounts.Where(x => x.AccountNumber == accountNumber).FirstOrDefaultAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return account;
        }                

        /// <summary>
        /// Создаем новый банковский счет в БД
        /// </summary>
        /// <param name="bankAccount"></param>
        /// <returns></returns>
        public async Task<BankAccount> CreateNewBankAccount(BankAccount bankAccount)
        {
            BankAccount? account = null;

            try
            {
                _dbContext.BankAccounts.Add(bankAccount);

                _dbContext.SaveChanges();

                account = bankAccount;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return account;

        }

        /// <summary>
        /// Создаем новую транзакцию в БД
        /// </summary>
        /// <param name="bankTransaction"></param>
        /// <returns></returns>
        public async Task<BankTransaction> CreateTransaction(BankTransaction bankTransaction)
        {
            BankTransaction? transaction = null;

            try
            {
                _dbContext.BankTransactions.Add(bankTransaction);

                _dbContext.SaveChanges();

                transaction = bankTransaction;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return transaction;
        }

        /// <summary>
        /// Получаем из БД список всех транзакции
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BankTransaction>> GetAllTransaction()
        {
            List<BankTransaction>? transactions = null;

            try
            {
                transactions = await _dbContext.BankTransactions
                                        .Include(x => x.BankAccount)
                                        .OrderBy(x => x.TransactionTime)
                                        .ToListAsync();                              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return transactions;
        }

        /// <summary>
        /// Получаем из БД список всех транзакции объекта bankAccount
        /// </summary>
        /// <param name="bankAccount"></param>
        /// <returns></returns>
        public async Task<IEnumerable<BankTransaction>> GetTransactionsByAccount(BankAccount bankAccount)
        {
            List<BankTransaction>? transactions = null;

            try
            {
                transactions = await _dbContext.BankTransactions
                                        .Include(x => x.BankAccount)
                                        .Where(x=> x.BankAccount == bankAccount)
                                        .OrderBy(x => x.TransactionTime)
                                        .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return transactions;
        }

        /// <summary>
        /// Получаем из БД список транзакции в соответсвии с pageParameters
        /// </summary>
        /// <param name="pageParameters"></param>
        /// <returns></returns>
        public async Task<IEnumerable<BankTransaction>> GetAllTransactionByPage(PageParameters pageParameters)
        {
            List<BankTransaction>? transactions = null;

            try
            {
                transactions = await _dbContext.BankTransactions
                                        .Include(x => x.BankAccount)
                                        .OrderBy(x => x.TransactionTime)
                                        .Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize)
                                        .Take(pageParameters.PageSize)
                                        .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return transactions;
        }

        /// <summary>
        /// Получаем из БД список транзакции объекта bankAccount в соответсвии с pageParameters
        /// </summary>
        /// <param name="bankAccount"></param>
        /// <param name="pageParameters"></param>
        /// <returns></returns>
        public async Task<IEnumerable<BankTransaction>> GetTransactionsByAccountByPage(BankAccount bankAccount, PageParameters pageParameters)
        {
            List<BankTransaction>? transactions = null;

            try
            {
                transactions = await _dbContext.BankTransactions
                                        .Include(x => x.BankAccount)
                                        .Where(x => x.BankAccount == bankAccount)
                                        .OrderBy(x => x.TransactionTime)
                                        .Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize)
                                        .Take(pageParameters.PageSize)
                                        .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return transactions;
        }
        #endregion
    }
    #endregion
}
