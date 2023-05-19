using ApiCreditCard.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCreditCard.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        // to autogenerate the tables we need to mention it into this class
        public DbSet<CreditCard> CreditCards { get; set; }
        // setting the default configuration file
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("CreditCardDB");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
