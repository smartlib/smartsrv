using System;

namespace SmartApp.Views
{
    public class CompanyData
    {
        public DateTime Date { get; set; }
        public double OpenValue { get; set; }
        public double CloseValue { get; set; }
        public double HighValue { get; set; }
        public double LowValue { get; set; }
        public double Volume { get; set; }

        public CompanyData(DateTime date, double open, double high, double low, double close, double volume)
        {
            this.Date = date;
            this.OpenValue = open;
            this.CloseValue = close;
            this.HighValue = high;
            this.LowValue = low;
            this.Volume = volume;
        }
    }
}