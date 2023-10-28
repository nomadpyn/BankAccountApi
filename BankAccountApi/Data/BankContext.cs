using Microsoft.EntityFrameworkCore;
using BankAccountApi.Models;

namespace BankAccountApi.Data
{
    public class BankContext : DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<BankTransaction> BankTransactions { get; set; }

        public BankContext(DbContextOptions<BankContext> options) : base(options) { }
    }
}
