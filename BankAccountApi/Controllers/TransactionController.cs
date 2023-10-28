#region Using
using Microsoft.AspNetCore.Mvc;
using BankAccountApi.Models.Dto;
using BankAccountApi.Models;
using BankAccountApi.Services;
using BankAccountApi.Utils;
using BankAccountApi.Services.Interfaces;
#endregion

namespace BankAccountApi.Controllers
{
    #region Public Class TransactionController

    /// <summary>
    /// Контроллер для работы с банковскими транзакциями
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        #region Private Fields

        /// <summary>
        /// Объект для работы с данными (БЛ)
        /// </summary>
        private readonly IBankWorker _transactionWorker;
        #endregion

        #region Constructor
        public TransactionController(IBankWorker transactionWorker)
        {
            _transactionWorker = transactionWorker;
        }
        #endregion

        #region Public Fields

        /// <summary>
        /// Получаем модель банковской транзакции для ее создания и возвращаем IActionResult в зависимости от результата
        /// </summary>
        /// <param name="transactionModel"></param>
        /// <returns></returns>
        [HttpPost("createTransaction")]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionModel transactionModel)
        {
            if (!CheckValue.ValidateTransactionModel(transactionModel))
            {
                return BadRequest("Неверный формат транзакции");
            }

            BankTransaction? result = await _transactionWorker.CreateBankTransaction(transactionModel);


            if (CheckValue.CheckEmptyBankTransaction(result))
            {
                return BadRequest("Ошибка проведения транзакции");
            }

            return Ok(result);
        }

        /// <summary>
        /// Ищем все банковские транзакции и возвращаем IActionResult в зависимости от результата
        /// </summary>
        /// <returns></returns>
        [HttpGet("transactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            IEnumerable<BankTransactionDto> result = await _transactionWorker.GetAllTransactions();

            if (result.Count() <= 0)
            {
                return BadRequest("Нет транзакции для отображения");
            }

            return Ok(result);
        }

        /// <summary>
        /// Ищем все банковские транзакции по номеру счета и возвращаем IActionResult в зависимости от результата
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        [HttpGet("transactions/{accountNumber}")]
        public async Task<IActionResult> GetTransactionsByAccountNumber(int accountNumber)
        {
            IEnumerable<BankTransactionDto> result = await _transactionWorker.GetTransactionsById(accountNumber);

            if (result.Count() <= 0)
            {
                return BadRequest("Нет транзакции для отображения");
            }

            return Ok(result);
        }

        /// <summary>
        /// Ищем все банковские транзакции в зависимости от pageParameters 
        /// и возвращаем IActionResult в зависимости от результата
        /// </summary>
        /// <param name="pageParameters"></param>
        /// <returns></returns>
        [HttpGet("transactionsbypage")]
        public async Task<IActionResult> GetAllTransactionsByPage([FromQuery] PageParameters pageParameters)
        {
            IEnumerable<BankTransactionDto> result = await _transactionWorker.GetAllTransactionsByPage(pageParameters);

            if (result.Count() <= 0)
            {
                return BadRequest("Нет транзакции для отображения");
            }

            return Ok(result);
        }

        /// <summary>
        /// Ищем все банковские транзакции по номеру счета  в зависимости от pageParameters  
        /// и возвращаем IActionResult в зависимости от результата
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="pageParameters"></param>
        /// <returns></returns>
        [HttpGet("transactionsbypage/{accountNumber}")]
        public async Task<IActionResult> GetTransactionsByAccountNumberByPage(int accountNumber, [FromQuery] PageParameters pageParameters)
        {
            IEnumerable<BankTransactionDto> result = await _transactionWorker.GetTransactionsByIdByPage(accountNumber, pageParameters);

            if (result.Count() <= 0)
            {
                return BadRequest("Нет транзакции для отображения");
            }

            return Ok(result);
        }
        #endregion
    }
    #endregion
}
