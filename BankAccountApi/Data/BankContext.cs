#region Using
using Microsoft.EntityFrameworkCore;
using BankAccountApi.Models;
#endregion

namespace BankAccountApi.Data
{
    #region Public Class BankContext

    /// <summary>
    /// Контекс для работы с БД
    /// </summary>
    public class BankContext : DbContext
    {
        #region Public Methods

        /// <summary>
        /// DbSet объектов BankAccount
        /// </summary>
        public DbSet<BankAccount> BankAccounts { get; set; }

        /// <summary>
        /// DbSet объектов BankTransaction
        /// </summary>
        public DbSet<BankTransaction> BankTransactions { get; set; }
        #endregion

        #region Constructor
        public BankContext(DbContextOptions<BankContext> options) : base(options) { }
        #endregion
    }
    #endregion
}
