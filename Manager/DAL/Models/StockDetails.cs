using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.DAL.Models
{
    public class StockDetails
    {
        public Guid Id { get; set; }
        public string stockName { get; set; }
        public float avgPrice { get; set; }
        public float change { get; set; }
        public float currentInvestmentValue { get; set; }
        public float currentSharePrice { get; set; }
        public float quantity { get; set; }
        public string sector { get; set; }
        public float totalInvestmentValue { get; set; }
        public float profitLoss { get; set; }
        public string status { get; set; }
        public float sellingPrice { get; set; }
        public float realizedProfitLoss { get; set; }
    }
}
