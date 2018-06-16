using Manager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.Services.ServiceModel
{
    public class StockServiceModel
    {
        public float totalProfitOnStocks { get; set; }
        public float totalLossOnStocks { get; set; }
        public List<StockDetails> getStockDetailsInProfit { get; set; }
        public List<StockDetails> getStockDetailsInLoss { get; set; }
    }
}
