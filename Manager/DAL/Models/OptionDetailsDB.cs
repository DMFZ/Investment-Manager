using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.DAL.Models
{
    public class OptionDetailsDB
    {
        public Guid Id { get; set; }
        public string optionName { get; set; }
        public float quantity { get; set; }
        public float avgPrice { get; set; }
        public float totalInvestmentValue { get; set; }
        public float currentOptionPrice { get; set; }
        public float currentInvestmentValue { get; set; }
        public float profitLoss { get; set; }
        public float change { get; set; }
        public string status { get; set; }
        public float charges { get; set; }
        public float sellingPrice { get; set; }
        public float realizedProfitLoss { get; set; }
    }
}
