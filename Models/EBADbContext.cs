using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EktivaBankNetApp.Models.ViewModel;

namespace EktivaBankNetApp.Models
{
    public class EBADbContext : DbContext
    {
        public EBADbContext(DbContextOptions<EBADbContext> context)
            : base(context)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"data source=.\SQLEXPRESS01;initial catalog=DbEBA;integrated security=True;MultipleActiveResultSets=True;");
            }
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet <Transaction> Transactions { get; set; }

        public DbSet<TransactionRange> TransactionsRange { get; set; }
    }
}
