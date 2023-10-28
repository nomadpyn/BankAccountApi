using Microsoft.AspNetCore.Mvc;
using BankAccountApi.Models;
using BankAccountApi.Models.Dto;
using BankAccountApi.Services;
using BankAccountApi.Services.Interfaces;
using BankAccountApi.Utils;

namespace BankAccountApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankAccountController : Controller
    {        
        private readonly IBankWorker _transactionWorker;

        public BankAccountController(IBankWorker transactionWorker)
        {            
            _transactionWorker = transactionWorker;
        }

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

        

    }
}
