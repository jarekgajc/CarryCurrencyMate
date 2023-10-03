using Backend.Models.Account;
using Backend.Models.User;
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
        public DbSet<User> Users { get; set; }
    }
}
