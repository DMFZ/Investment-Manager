using Manager.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.API.Models
{
    public class OptionAddRequest
    {
        [JsonProperty("data"), ValidateObject]
        public Option NewOption { get; set; }
    }

    public class Option
    {
        public string optionName { get; set; }
        public float quantity { get; set; }
        public float avgPrice { get; set; }
        public float totalInvestmentValue { get; set; }
        public float currentOptionPrice { get; set; }
        public float currentInvestmentValue { get; set; }
        public float profitLoss { get; set; }
        public float change { get; set; }
        public string status { get; set; }
    }
}
