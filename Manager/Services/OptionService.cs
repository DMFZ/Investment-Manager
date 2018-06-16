using Manager.API.Models;
using Manager.DAL;
using Manager.DAL.Models;
using Manager.Services.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.Services
{
    public class OptionService
    {
        public List<OptionDetailsDB> GetAllOptions()
        {
            var allOptions = new List<OptionDetailsDB>();
            try
            {
                using (var context = new Context())
                {
                    allOptions = (from data in context.optionDetails
                                    where data.status == "HOLD"
                                    select data).OrderBy(x => x.optionName).ToList();
                    foreach (var data in allOptions)
                    {
                        data.totalInvestmentValue = float.Parse(string.Format("{0:#,###0.00}", data.totalInvestmentValue));
                        data.currentInvestmentValue = float.Parse(string.Format("{0:#,###0.00}", data.currentInvestmentValue));
                        data.profitLoss = float.Parse(string.Format("{0:#,###0.00}", data.profitLoss));
                        data.change = float.Parse(string.Format("{0:#,###0.00}", data.change));
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return allOptions;
        }

        public bool AddNewOptionTransaction(Option newOption)
        {
            var stockRecord = new OptionDetailsDB();
            stockRecord.optionName = newOption.optionName;
            stockRecord.currentOptionPrice = newOption.currentOptionPrice;
            stockRecord.currentInvestmentValue = newOption.currentOptionPrice * newOption.quantity;
            stockRecord.avgPrice = newOption.avgPrice;
            stockRecord.totalInvestmentValue = newOption.avgPrice * newOption.quantity;
            stockRecord.quantity = newOption.quantity;
            stockRecord.profitLoss = stockRecord.currentInvestmentValue - stockRecord.totalInvestmentValue;
            stockRecord.change = (stockRecord.profitLoss / stockRecord.totalInvestmentValue) * 100;
            stockRecord.status = "HOLD";
            try
            {
                using (var context = new Context())
                {
                    context.Add(stockRecord);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool SellOption(Option editOption)
        {
            using(var context= new Context())
            {
                var existingRecord = context.optionDetails.Where(x => x.optionName.Equals(editOption.optionName,StringComparison.InvariantCultureIgnoreCase) && x.status.ToUpper() == "HOLD").FirstOrDefault();
                existingRecord.status = "SOLD";
                var lots = editOption.quantity % 75;
                var brokerage = 40 * lots;
                var charges = .18 * (brokerage + (.053 * editOption.currentOptionPrice + .053 * editOption.avgPrice));
                context.SaveChanges();
                return true;
            }
        }
    }
}
