using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SmartApp.Views
{
    public class Company
    {
        private ObservableCollection<CompanyData> stockData;

        public Company(string name, string shortName)
        {
            this.Name = name;
            this.ShortName = shortName;
        }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public string CompanyColor { get; set; }
        public double DifferenceInPercentage { get; set; }
        public double LatestStockCloseValue { get; set; }
        public bool IsValueGoingUp { get; set; }
        public double LatestStockVolume { get; set; }

        public ObservableCollection<CompanyData> StockData
        {
            get
            {
                return this.stockData;
            }
            set
            {
                if (this.stockData != value)
                {
                    this.stockData = value;
                    if (this.stockData.Any())
                    {
                        var orderedStockData = this.stockData.OrderBy(d => d.Date).ToList();
                        var latestStockData = this.StockData[this.StockData.Count - 1];
                        var previousLatestStockData = this.StockData[this.StockData.Count - 2];

                        var latestStockCloseValue = latestStockData.CloseValue;
                        var previousLatestStockCloseValue = previousLatestStockData.CloseValue;

                        this.LatestStockVolume = latestStockData.Volume;
                        this.LatestStockCloseValue = latestStockCloseValue;
                        this.IsValueGoingUp = latestStockCloseValue > previousLatestStockCloseValue;
                        this.DifferenceInPercentage = (latestStockCloseValue - previousLatestStockCloseValue) / ((latestStockCloseValue + previousLatestStockCloseValue) / 2) * 100;
                    }
                }
            }
        }
    }
}