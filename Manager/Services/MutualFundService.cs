using Manager.API.Models;
using Manager.DAL;
using Manager.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.Services
{
    public class MutualFundService
    {
        public List<MutualFundsDetail> GetAllMutualFunds()
        {
            var mutualFundDetails = new List<MutualFundsDetail>();
            try
            {
                using (var context = new Context())
                {
                    mutualFundDetails = (from data in context.MFDetails
                                    select data).OrderBy(x => x.MutualFundName).ToList();
                    foreach (var data in mutualFundDetails)
                    {
                        data.TotalInvestmentValue = float.Parse(string.Format("{0:#,###0.00}", data.TotalInvestmentValue));
                        data.CurrentInvestmentValue = float.Parse(string.Format("{0:#,###0.00}", data.CurrentInvestmentValue));
                        data.ProfitLoss = float.Parse(string.Format("{0:#,###0.00}", data.ProfitLoss));
                        data.Change = float.Parse(string.Format("{0:#,###0.00}", data.Change));
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return mutualFundDetails;
        }

        public bool AddMfData(MutualFund newStock)
        {
            var mfRecord = new MutualFundsDetail();
            mfRecord.MutualFundName = newStock.MutualFundName;
            mfRecord.CurrentNAV = newStock.CurrentNAV;
            mfRecord.CurrentInvestmentValue = newStock.CurrentNAV * newStock.UnitsHeld;
            mfRecord.InvestmentNAV = newStock.InvestmentNAV;
            mfRecord.TotalInvestmentValue = newStock.InvestmentNAV * newStock.UnitsHeld;
            mfRecord.UnitsHeld = newStock.UnitsHeld;
            mfRecord.ProfitLoss = mfRecord.CurrentInvestmentValue - mfRecord.TotalInvestmentValue;
            mfRecord.Change = (mfRecord.ProfitLoss / mfRecord.TotalInvestmentValue) * 100;
            try
            {
                using (var context = new Context())
                {
                    var existingRecord = context.MFDetails.FirstOrDefault(x => x.MutualFundName.Equals(newStock.MutualFundName, StringComparison.InvariantCultureIgnoreCase));
                    if (existingRecord != null && existingRecord.MutualFundName.Equals(mfRecord.MutualFundName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        existingRecord.TotalInvestmentValue = existingRecord.TotalInvestmentValue + mfRecord.TotalInvestmentValue;
                        existingRecord.Change = existingRecord.Change + newStock.Change;
                        existingRecord.InvestmentNAV = mfRecord.TotalInvestmentValue / mfRecord.Change;
                        context.Update(existingRecord);
                    }
                    else
                    {
                        context.Add(mfRecord);
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
