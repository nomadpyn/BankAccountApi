#region Using
using Microsoft.AspNetCore.Mvc;
using BankAccountApi.Models;
using BankAccountApi.Services.Interfaces;
using BankAccountApi.Utils;
#endregion

namespace BankAccountApi.Controllers
{
    #region Public Class BankAccountController

    /// <summary>
    /// Контроллер для работы с банковским аккаунтом
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BankAccountController : Controller
    {
        #region Private Fields

        /// <summary>
        /// Объект для работы с данными (БЛ)
        /// </summary>
        private readonly IBankWorker _transactionWorker;
        #endregion

        #region Constructor
        public BankAccountController(IBankWorker transactionWorker)
        {            
            _transactionWorker = transactionWorker;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Получаем номер счета для его поиска и возвращаем IActionResult в зависимости от результата
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        [HttpGet("{accountNumber}")]        
        public async Task<IActionResult> GetCurrentAccount(int accountNumber)
        {
            if(!CheckValue.ValidateAccountNumber(accountNumber)) 
            {
                return BadRequest("Не верный формат номера банковского счета");
            }

            BankAccount? result = await _transactionWorker.GetBankAccountByAccountNumber(accountNumber);

            if(CheckValue.CheckEmptyBankAccount(result))
            {
                return NoContent();
            }

            return Ok(result);
        }

        /// <summary>
        /// Получаем номер счета для его поиска и вывода суммы на счету и возвращаем IActionResult в зависимости от результата
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        [HttpGet("balance/{accountNumber}")]
        public async Task<IActionResult> GetAmountByAccount(int accountNumber)
        {
            if (!CheckValue.ValidateAccountNumber(accountNumber))
            {
                return BadRequest("Не верный формат номера банковского счета");
            }

            BankAccount? result = await _transactionWorker.GetBankAccountByAccountNumber(accountNumber);

            if (CheckValue.CheckEmptyBankAccount(result))
            {
                return NoContent();
            }

            return Ok(result.Amount);
        }

        /// <summary>
        /// Получаем новый банковский счет для его создания и возвращаем IActionResult в зависимости от результата
        /// </summary>
        /// <param name="bankAccount"></param>
        /// <returns></returns>
        [HttpPost("createBankAccount")]
        public async Task<IActionResult> CreateBankAccount([FromBody] BankAccount bankAccount)
        {
            if (!CheckValue.CheckNewBankAccount(bankAccount))
            {
                return BadRequest("Не корректные данные банковского счета");
            }

            BankAccount? result = await _transactionWorker.CreateBankAccount(bankAccount);

            if (CheckValue.CheckEmptyBankAccount(result))
            {
                return BadRequest("Ошибка создания банковского счета");
            }

            return Ok(result);
        }
        #endregion
    }
    #endregion
}
