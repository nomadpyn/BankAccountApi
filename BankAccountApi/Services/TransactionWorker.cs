using AutoMapper;
using System.Linq.Expressions;
using BankAccountApi.Models;
using BankAccountApi.Models.Dto;
using BankAccountApi.Services.Interfaces;
using BankAccountApi.Utils;
using BankAccountApi.Utils.Helpers;

namespace BankAccountApi.Services
{
    public class TransactionWorker : IBankWorker
    {
        private IBankRepository _bankRepository;
        private IMapper _mapper;

        private delegate Task<decimal> TransactionSignDelegate(decimal amount, decimal sum);
        public TransactionWorker(IBankRepository bankRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _mapper = mapper;
        }

        public async Task <BankAccount> GetBankAccountByAccountNumber(int accountNumber)
        {
            BankAccount data = await _bankRepository.GetBankAccount(accountNumber);

            return CheckValue.CheckEmptyBankAccount(data) ? new BankAccount() : data;
        }

        public async Task<BankAccount> CreateBankAccount(BankAccount newBankAccount)
        {
            BankAccount? existAccount = await _bankRepository.GetBankAccount(newBankAccount.AccountNumber);

            BankAccount? createdAccount = new BankAccount();

            if(CheckValue.CheckEmptyBankAccount(existAccount)) 
            {
                createdAccount = CheckValue.CheckEmptyBankAccount(newBankAccount) ? new BankAccount() : await _bankRepository.CreateNewBankAccount(newBankAccount);
            }

            return createdAccount;            
        }

        public async Task<BankTransaction> CreateBankTransaction(TransactionModel transactionModel)
        {
            BankTransaction? createdTransaction = null;

            if (CheckValue.ValidateTransactionModel(transactionModel) )
            {
                createdTransaction = await CreateNewTransaction(transactionModel);
            }

            return CheckValue.CheckEmptyBankTransaction(createdTransaction) ? new BankTransaction() : createdTransaction;
        }
        public async Task<IEnumerable<BankTransactionDto>> GetAllTransactions()
        {
            IEnumerable<BankTransaction> bankTransactions = await _bankRepository.GetAllTransaction();

            IEnumerable<BankTransactionDto>? bankTransactionDtos = null;

            try
            {
                bankTransactionDtos = _mapper.Map<IEnumerable<BankTransaction>, IEnumerable<BankTransactionDto>>(bankTransactions);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return bankTransactionDtos == null ? new List<BankTransactionDto>() : bankTransactionDtos;

        }

        public async Task<IEnumerable<BankTransactionDto>> GetTransactionsById(int accountNumber)
        {
            BankAccount? account = await _bankRepository.GetBankAccount(accountNumber);

            IEnumerable<BankTransactionDto>? bankTransactionDtos = null;

            if (!CheckValue.CheckEmptyBankAccount(account))
            {
                IEnumerable<BankTransaction> bankTransactions = await _bankRepository.GetTransactionsByAccount(account);

                try
                {
                    bankTransactionDtos = _mapper.Map<IEnumerable<BankTransaction>, IEnumerable<BankTransactionDto>>(bankTransactions);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            return bankTransactionDtos == null ? new List<BankTransactionDto>() : bankTransactionDtos;
        }

        public async Task<IEnumerable<BankTransactionDto>> GetAllTransactionsByPage(PageParameters pageParameters)
        {
            IEnumerable<BankTransaction> bankTransactions = await _bankRepository.GetAllTransactionByPage(pageParameters);

            IEnumerable<BankTransactionDto>? bankTransactionDtos = null;

            try
            {
                bankTransactionDtos = _mapper.Map<IEnumerable<BankTransaction>, IEnumerable<BankTransactionDto>>(bankTransactions);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return bankTransactionDtos == null ? new List<BankTransactionDto>() : bankTransactionDtos;

        }

        public async Task<IEnumerable<BankTransactionDto>> GetTransactionsByIdByPage(int accountNumber, PageParameters pageParameters)
        {
            BankAccount? account = await _bankRepository.GetBankAccount(accountNumber);

            IEnumerable<BankTransactionDto>? bankTransactionDtos = null;

            if (!CheckValue.CheckEmptyBankAccount(account))
            {
                IEnumerable<BankTransaction> bankTransactions = await _bankRepository.GetTransactionsByAccountByPage(account, pageParameters);

                try
                {
                    bankTransactionDtos = _mapper.Map<IEnumerable<BankTransaction>, IEnumerable<BankTransactionDto>>(bankTransactions);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            return bankTransactionDtos == null ? new List<BankTransactionDto>() : bankTransactionDtos;
        }

        private async Task<BankTransaction> CreateNewTransaction(TransactionModel transactionModel)
        {
            BankAccount? existAccount = await _bankRepository.GetBankAccount(transactionModel.BankAccountId);

            BankTransaction? createdTransaction = null;

            TransactionSignDelegate transactionSignDelegate = ChouseTransactionSign(transactionModel);

            if (!CheckValue.CheckEmptyBankAccount(existAccount) && transactionSignDelegate != null)
            {
                decimal transactionResult = await transactionSignDelegate(existAccount.Amount, transactionModel.TransactionSum);

                if (CheckValue.CheckTransactionResult(transactionResult))
                {
                    existAccount.Amount = transactionResult;

                    BankTransaction bankTransaction = new BankTransaction()
                    {
                        BankAccount = existAccount,
                        BalanceAfterTransaction = existAccount.Amount,
                        TransactionSign = transactionModel?.TransactionSign?.ToUpper(),
                        TransactionSum = transactionModel.TransactionSum,
                        TransactionTime = DateTimeOffset.UtcNow
                    };

                    createdTransaction = await _bankRepository.CreateTransaction(bankTransaction);

                }
            }
                return CheckValue.CheckEmptyBankTransaction(createdTransaction) ? new BankTransaction() : createdTransaction;
        }

        private async Task<Decimal> IncomeBankAccountAmount(decimal currentAmount, decimal incomeSum)
        {
            return currentAmount + incomeSum;
        }

        private async Task<Decimal> ExpenseBankAccountAmount(decimal currentAmount, decimal expenseSum)
        {
            if (expenseSum < currentAmount)
                return currentAmount - expenseSum;
            else return -1;
        }

        private TransactionSignDelegate ChouseTransactionSign(TransactionModel transactionModel)
        {
            TransactionSignDelegate? transactionSignDelegate = null;

            try
            {
                switch (transactionModel?.TransactionSign?.ToLower())
                {
                    case TransactionModelValue.Income:
                        {
                            transactionSignDelegate = IncomeBankAccountAmount;
                            break;
                        }
                    case TransactionModelValue.Expense:
                        {
                            transactionSignDelegate = ExpenseBankAccountAmount;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return transactionSignDelegate;
        }       
    }
}
