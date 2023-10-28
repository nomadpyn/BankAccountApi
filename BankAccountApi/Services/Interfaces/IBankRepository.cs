using BankAccountApi.Models;

namespace BankAccountApi.Services.Interfaces
{
    public interface IBankRepository
    {
        Task<BankAccount> GetBankAccount(int accountNumber);
        Task<BankAccount> CreateNewBankAccount(BankAccount bankAccount);
        Task<BankTransaction> CreateTransaction(BankTransaction bankTransaction);
        Task<IEnumerable<BankTransaction>> GetAllTransaction();
        Task<IEnumerable<BankTransaction>> GetTransactionsByAccount(BankAccount bankAccount);
        Task<IEnumerable<BankTransaction>> GetAllTransactionByPage(PageParameters pageParameters);
        Task<IEnumerable<BankTransaction>> GetTransactionsByAccountByPage(BankAccount bankAccount,PageParameters pageParameters);
    }
}
