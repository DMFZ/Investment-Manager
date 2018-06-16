using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.Services.ServiceModel
{
    public class OptionDetails
    {
        public string optionName { get; set; }
        public float quantity { get; set; }
        public float avgPrice { get; set; }
        public float totalInvestmentValue { get; set; }
        public float currentOptionPrice { get; set; }
        public float currentInvestmentValue { get; set; }
        public float profitLosee { get; set; }
        public float change { get; set; }
    }
}
