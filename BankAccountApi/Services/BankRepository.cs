using Microsoft.EntityFrameworkCore;
using BankAccountApi.Data;
using BankAccountApi.Models;
using BankAccountApi.Services.Interfaces;

namespace BankAccountApi.Services
{
    public class BankRepository : IBankRepository
    {
        private readonly BankContext _dbContext;

        public BankRepository(BankContext dbContext)
        {
            _dbContext = dbContext;
        }

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
    }
}
