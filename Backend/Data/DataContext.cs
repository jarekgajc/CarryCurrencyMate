using Backend.Models.Accounts;
using Backend.Models.Exchangers;
using Backend.Models.Observers;
using Backend.Models.Sources.Auths;
using Backend.Models.Transactions;
using Backend.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=carrry_currency_mate;Trusted_Connection=True;TrustServerCertificate=true;");
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountPreference> AccountPreferences { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Observer> Observers { get; set; }
        public DbSet<Exchanger> Exchangers { get; set; }
        public DbSet<SourceAuth> SourceAuths { get; set; }
        public DbSet<TransactionSource> TransactionSources { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
