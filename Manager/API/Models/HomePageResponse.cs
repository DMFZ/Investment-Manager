using Manager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.API.Models
{
    public class HomePageResponse
    {
        public StockDetails allStocks { get; set; }
        public double amountInStocks { get; set; }
        public double currentValueStocks { get; set; }
        public double profitLossStocks { get; set; }
        public double changeStocks { get; set; }

        public MutualFundsDetail allFunds { get; set; }
        public double amountInFunds { get; set; }
        public double currentValueFunds { get; set; }
        public double profitLossFunds { get; set; }
        public double changeFunds { get; set; }
    }
}
