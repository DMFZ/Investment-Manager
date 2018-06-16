using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.Helpers;

namespace Manager.API_Controllers.Models
{
    public class StockAddRequest
    {
        [JsonProperty("data"), ValidateObject]
        public Stock data { get; set; }
    }

    public class Stock
    {
        public string stockName { get; set; }
        public float avgPrice { get; set; }
        public float change { get; set; }
        public float currentInvestmentValue { get; set; }
        public float currentSharePrice { get; set; }
        public float quantity { get; set; }
        public string sector { get; set; }
        public float totalInvestmentValue { get; set; }
        public float sellingPrice { get; set; }
        public float realizedProfitLoss { get; set; }
        public string status { get; set; }
    }
}
