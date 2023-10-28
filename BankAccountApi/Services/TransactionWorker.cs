#region Using
using AutoMapper;
using System.Linq.Expressions;
using BankAccountApi.Models;
using BankAccountApi.Models.Dto;
using BankAccountApi.Services.Interfaces;
using BankAccountApi.Utils;
using BankAccountApi.Utils.Helpers;
#endregion

namespace BankAccountApi.Services
{
    #region Using Public Class TransactionWorker

    /// <summary>
    /// БЛ приложения, класс для работы с данными и их валидацией
    /// </summary>
    public class TransactionWorker : IBankWorker
    {
        #region Private Fields

        /// <summary>
        /// Репозитори для обращения к БД
        /// </summary>
        private IBankRepository _bankRepository;

        /// <summary>
        /// Маппер
        /// </summary>
        private IMapper _mapper;

        /// <summary>
        /// Делегат для выбора операции типа транзакции (поступление, снятие)
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        private delegate Task<decimal> TransactionSignDelegate(decimal amount, decimal sum);
        #endregion

        #region Constructor
        public TransactionWorker(IBankRepository bankRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _mapper = mapper;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Получаем из репозитории банковский счет по номеру счета, если он пустой или null, то возвращаем новый обьект
        /// или полученный корректный из БД
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public async Task <BankAccount> GetBankAccountByAccountNumber(int accountNumber)
        {
            BankAccount data = await _bankRepository.GetBankAccount(accountNumber);

            return CheckValue.CheckEmptyBankAccount(data) ? new BankAccount() : data;
        }

        /// <summary>
        /// Создаем новый банковский счет, если такого не существует и возвращает его
        /// В случае ошибки возвращаем новый пустой объект для дальнейшей обработки
        /// </summary>
        /// <param name="newBankAccount"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Создаем банковскую транзакцию и возвращаем ее, в случае ошибки возвращаем пустой объект BankTransaction 
        /// для дальнейшей обработки
        /// </summary>
        /// <param name="transactionModel"></param>
        /// <returns></returns>
        public async Task<BankTransaction> CreateBankTransaction(TransactionModel transactionModel)
        {
            BankTransaction? createdTransaction = null;

            if (CheckValue.ValidateTransactionModel(transactionModel) )
            {
                createdTransaction = await CreateNewTransaction(transactionModel);
            }

            return CheckValue.CheckEmptyBankTransaction(createdTransaction) ? new BankTransaction() : createdTransaction;
        }

        /// <summary>
        /// Получаем список всех транзакций, преобразуем из в ДТО, в случае ошибки возващаем пустой список для дальнейшей обработки
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Получаем список всех транзакций по номеру счета, преобразуем из в ДТО,
        /// в случае ошибки возващаем пустой список для дальнейшей обработки
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Получаем список всех транзакций по pageParameteres, преобразуем из в ДТО, 
        /// в случае ошибки возващаем пустой список для дальнейшей обработки
        /// </summary>
        /// <param name="pageParameters"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Получаем список всех транзакций по номеру счета и pageParameters, преобразуем из в ДТО,
        /// в случае ошибки возващаем пустой список для дальнейшей обработки
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="pageParameters"></param>
        /// <returns></returns>
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
        #endregion

        #region Private Methods

        /// <summary>
        /// Создание новой транзакции для записи в БД и возвращаем ее, в случае ошибки возвращаем пустой объект
        /// для его дальейшей обработки
        /// </summary>
        /// <param name="transactionModel"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Расчет при операции пополнении
        /// </summary>
        /// <param name="currentAmount"></param>
        /// <param name="incomeSum"></param>
        /// <returns></returns>
        private async Task<Decimal> IncomeBankAccountAmount(decimal currentAmount, decimal incomeSum)
        {
            return currentAmount + incomeSum;
        }

        /// <summary>
        /// Расчет при операции снятия
        /// </summary>
        /// <param name="currentAmount"></param>
        /// <param name="expenseSum"></param>
        /// <returns></returns>
        private async Task<Decimal> ExpenseBankAccountAmount(decimal currentAmount, decimal expenseSum)
        {
            if (expenseSum < currentAmount)
                return currentAmount - expenseSum;
            else return -1;
        }

        /// <summary>
        /// Возвращаем делегат, в зависимости от признака транзакции
        /// </summary>
        /// <param name="transactionModel"></param>
        /// <returns></returns>
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
        #endregion
    }
    #endregion
}
