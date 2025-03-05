using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialCrm.Models;


namespace FinancialCrm
{
    public class FinancialCrmDbContext : DbContext
    {

        public FinancialCrmDbContext() : base("name=FinancialCrmDbEntities1")
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankProcess> BankProcesses { get; set; }
        public DbSet<Bill> Bills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        

    }
}
