namespace BankAccountApi.Models.Dto
{
    public class BankTransactionDto
    {
        public int AccountNumber { get; set; }
        public DateTimeOffset TransactionTime { get; set; }
        public string? TransactionSign { get; set; }
        public decimal TransactionSum { get; set; }
        public decimal BalanceAfterTransaction { get; set; }
    }
}
