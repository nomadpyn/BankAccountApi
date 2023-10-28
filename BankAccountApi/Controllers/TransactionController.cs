using Microsoft.AspNetCore.Mvc;
using BankAccountApi.Models.Dto;
using BankAccountApi.Models;
using BankAccountApi.Services;
using BankAccountApi.Utils;
using BankAccountApi.Services.Interfaces;

namespace BankAccountApi.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class TransactionController : Controller
        {
        private readonly IBankWorker _transactionWorker;
        public TransactionController(IBankWorker transactionWorker)
        {
            _transactionWorker = transactionWorker;
        }
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

        [HttpGet("transactionsbypage")]
        public async Task<IActionResult> GetAllTransactionsByPage([FromQuery]PageParameters pageParameters)
        {
            IEnumerable<BankTransactionDto> result = await _transactionWorker.GetAllTransactionsByPage(pageParameters);

            if (result.Count() <= 0)
            {
                return BadRequest("Нет транзакции для отображения");
            }

            return Ok(result);
        }

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

    }
}
