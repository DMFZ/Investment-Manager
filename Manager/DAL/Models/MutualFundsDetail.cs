using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.DAL.Models
{
    public class MutualFundsDetail
    {
        public Guid Id { get; set; }
        public string MutualFundName { get; set; }
        public float InvestmentNAV { get; set; }
        public float CurrentNAV { get; set; }
        public float UnitsHeld { get; set; }
        public float Change { get; set; }
        public float ProfitLoss { get; set; }
        public float TotalInvestmentValue { get; set; }
        public float CurrentInvestmentValue { get; set; }
    }
}
