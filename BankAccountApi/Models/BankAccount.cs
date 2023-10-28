using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BankAccountApi.Models
{
    public class BankAccount
    {
        public int Id { get; set; }                
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }

    }
}
