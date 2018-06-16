using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Manager.DAL.Models;

namespace Manager.DAL
{
    public class Context: DbContext
    {
        public DbSet<StockDetails> stockDetails { get; set; }

        public DbSet<MutualFundsDetail> MFDetails { get; set; }

        public DbSet<OptionDetailsDB> optionDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=MoneyManager;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
