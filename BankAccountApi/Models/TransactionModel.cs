namespace BankAccountApi.Models
{
    public class TransactionModel
    {
        public string? TransactionSign { get; set; }
        public int BankAccountId { get; set; }
        public decimal TransactionSum {  get; set; }
    }
}
