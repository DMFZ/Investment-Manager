using Manager.API_Controllers.Models;
using Manager.DAL;
using Manager.DAL.Models;
using Manager.Services.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.Helpers;

namespace Manager.Services
{
    public class StockService
    {
        ImportFromExcel imprt = new ImportFromExcel();
        public bool AddNewStock(Stock newStock)
        {
            var stockRecord = new StockDetails();
            stockRecord.stockName = newStock.stockName;
            stockRecord.currentSharePrice = newStock.currentSharePrice;
            stockRecord.currentInvestmentValue = newStock.currentSharePrice* newStock.quantity;
            stockRecord.sector = newStock.sector;
            stockRecord.avgPrice = newStock.avgPrice;
            stockRecord.totalInvestmentValue = newStock.avgPrice* newStock.quantity;
            stockRecord.quantity = newStock.quantity;
            stockRecord.profitLoss = stockRecord.currentInvestmentValue - stockRecord.totalInvestmentValue;
            stockRecord.change = (stockRecord.profitLoss/ stockRecord.totalInvestmentValue)*100;
            stockRecord.status = string.IsNullOrWhiteSpace(newStock.status) ? "HOLD" : newStock.status;
            try
            {
                using (var context = new Context())
                {
                    var existingRecord = context.stockDetails.FirstOrDefault(x => x.stockName.Equals(newStock.stockName,StringComparison.InvariantCultureIgnoreCase));
                    if (existingRecord != null && existingRecord.stockName.Equals(stockRecord.stockName,StringComparison.InvariantCultureIgnoreCase))
                    {
                        existingRecord.totalInvestmentValue = existingRecord.totalInvestmentValue + stockRecord.totalInvestmentValue;
                        existingRecord.quantity = existingRecord.quantity + newStock.quantity;
                        existingRecord.avgPrice = stockRecord.totalInvestmentValue / stockRecord.quantity;
                        context.Update(existingRecord);
                    }
                    else
                    {
                        context.Add(stockRecord);
                    }
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public List<StockDetails> GetAllStocksData()
        {
            var stockDetails = new List<StockDetails>();
            try
            {
                using (var context = new Context())
                {
                    stockDetails = (from data in context.stockDetails
                                    where data.status == "HOLD"
                                    select data).OrderBy(x => x.stockName).ToList();
                    foreach (var data in stockDetails)
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
            return stockDetails;
        }

        public StockServiceModel GetStocksRelatedData()
        {
            var data = new StockServiceModel();
            using (var context = new Context())
            {
                var stockDetails = (from stockData in context.stockDetails
                                    select stockData).OrderBy(x => x.stockName).ToList();
                data.totalProfitOnStocks = float.Parse(string.Format("{0:#,###0.00}", stockDetails.Where(x => x.profitLoss > 0.00).Sum(x => x.profitLoss)));
                data.totalLossOnStocks = float.Parse(string.Format("{0:#,###0.00}", stockDetails.Where(x => x.profitLoss < 0.00).Sum(x => x.profitLoss)));
                data.getStockDetailsInProfit = (from detail in stockDetails
                                                where detail.profitLoss > 0
                                                select detail).ToList();
                data.getStockDetailsInLoss = (from detail in stockDetails
                                                where detail.profitLoss < 0
                                                select detail).ToList();
            }
            return data;
        }

        public bool UpdateStock(Stock updateStock)
        {
            try
            {
                using (var context = new Context())
                {
                    var stockRecord = context.stockDetails.Where(x => x.stockName.Equals(updateStock.stockName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                    if (stockRecord != null)
                    {
                        stockRecord.sector = updateStock.sector;
                        stockRecord.currentSharePrice = updateStock.currentSharePrice;
                        stockRecord.avgPrice = updateStock.avgPrice;
                        stockRecord.quantity = updateStock.quantity;
                        stockRecord.currentInvestmentValue = updateStock.currentSharePrice * stockRecord.quantity;
                        stockRecord.totalInvestmentValue = updateStock.quantity * updateStock.avgPrice;
                        stockRecord.profitLoss = stockRecord.currentInvestmentValue - stockRecord.totalInvestmentValue;
                        stockRecord.change = (stockRecord.profitLoss / stockRecord.totalInvestmentValue) * 100;
                        context.Update(stockRecord);
                        context.SaveChanges();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool ProcessFileImport(out string list)
        {
            int count = 0;
            string listOfStocks = "";
            try
            {
                var processStockData = imprt.ReadExcel(@"G:\holdings.xlsx");
                foreach (var stockData in processStockData)
                {
                    if (UpdateStock(stockData))
                    {
                        listOfStocks += stockData.stockName + ";";
                    }
                }
                
            }
            catch (Exception ex)
            {
                list = "";
                return false;
            }
            list = listOfStocks;
            return true;
        }

        public bool SellStock(Stock updateStock)
        {
            using (var context = new Context())
            {
                var existingRecord = context.stockDetails.Where(x => x.stockName.Equals(updateStock.stockName, StringComparison.InvariantCultureIgnoreCase) && x.status.ToUpper() == "HOLD").FirstOrDefault();
                if (existingRecord.quantity != updateStock.quantity)
                {
                    var stockRecord = new Stock();
                    stockRecord.stockName = updateStock.stockName;
                    stockRecord.sellingPrice = updateStock.sellingPrice;
                    stockRecord.sector = updateStock.sector;
                    stockRecord.avgPrice = updateStock.avgPrice;
                    stockRecord.quantity = updateStock.quantity;
                    stockRecord.status = "SOLD";
                    AddNewStock(stockRecord);
                    var updateStockData = new Stock();
                    updateStockData.currentSharePrice = existingRecord.currentSharePrice;
                    updateStockData.sector = existingRecord.sector;
                    updateStockData.avgPrice = existingRecord.avgPrice;
                    updateStockData.quantity = existingRecord.quantity - updateStock.quantity;
                    updateStockData.sector = updateStock.sector;
                    UpdateStock(updateStockData);
                }
                else if(existingRecord.quantity==updateStock.quantity)
                {
                    existingRecord.realizedProfitLoss = updateStock.quantity * (updateStock.sellingPrice - updateStock.avgPrice);
                    existingRecord.status = "SOLD";
                }
                context.SaveChanges();
                return true;
            }
        }
    }
}
