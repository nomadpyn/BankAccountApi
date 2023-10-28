using BankAccountApi.Models;
using BankAccountApi.Models.Dto;

namespace BankAccountApi.Services.Interfaces
{
    public interface IBankWorker
    {
        Task<BankAccount> GetBankAccountByAccountNumber (int accountNumber);
        Task<BankAccount> CreateBankAccount(BankAccount bankAccount);
        Task<BankTransaction> CreateBankTransaction(TransactionModel transactionModel);
        Task<IEnumerable<BankTransactionDto>> GetAllTransactions();
        Task<IEnumerable<BankTransactionDto>> GetTransactionsById( int accountNumber);

        Task<IEnumerable<BankTransactionDto>> GetAllTransactionsByPage(PageParameters pageParameters);

        Task<IEnumerable<BankTransactionDto>> GetTransactionsByIdByPage(int accountNumber, PageParameters pageParameters);
    }
}
