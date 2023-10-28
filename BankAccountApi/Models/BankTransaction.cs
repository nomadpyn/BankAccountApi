using Microsoft.EntityFrameworkCore;

namespace BankAccountApi.Models
{
    public class BankTransaction
    {
        public int Id { get; set; }
        public DateTimeOffset TransactionTime { get; set; }
        public string? TransactionSign { get; set; }
        public decimal TransactionSum { get; set; }
        public decimal BalanceAfterTransaction { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}
