using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace SmartApp.Views
{
    public class StocksViewModel
    {
        public ObservableCollection<Company> Companies { get; set; }

        public StocksViewModel()
        {
            this.Companies = this.GetData("stocks.csv");
        }

        private ObservableCollection<Company> GetData(string fileName)
        {
            fileName = "SmartApp.Views.StocksSampleData." + fileName;
            var assembly = typeof(StocksViewModel).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(fileName);

            using (var reader = new StreamReader(stream))
            {
                return this.ParseData(reader);
            }
        }

        public ObservableCollection<Company> ParseData(TextReader dataReader)
        {
            var companies = new ObservableCollection<Company>();
            var chartData = new ObservableCollection<CompanyData>();
            Company company = null;
            string line;
            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                string[] data = line.Split(',');
                string name = data[0];

                if (company != null && company.Name != name)
                {
                    company.StockData = chartData;
                    companies.Add(company);
                    company = null;
                    chartData = new ObservableCollection<CompanyData>();
                }

                if (company == null)
                {
                    string shortName = name.Split(' ')[0].ToUpper();
                    company = new Company(name, shortName);
                    company.CompanyColor = this.GetCompanyColor(name);
                }

                var date = DateTime.Parse(data[1], CultureInfo.InvariantCulture);
                var open = double.Parse(data[2], CultureInfo.InvariantCulture);
                var high = double.Parse(data[3], CultureInfo.InvariantCulture);
                var low = double.Parse(data[4], CultureInfo.InvariantCulture);
                var close = double.Parse(data[5], CultureInfo.InvariantCulture);
                var volume = double.Parse(data[6], CultureInfo.InvariantCulture);
                var companyData = new CompanyData(date, open, high, low, close, volume);
                chartData.Add(companyData);
            }

            if (company != null)
            {
                company.StockData = chartData;
                companies.Add(company);
            }

            return companies;
        }

        private string GetCompanyColor(string name)
        {
            string color;
            if (name.Contains("Apple"))
            {
                color = "#ff29ABE2";
            }
            else if (name.Contains("Nasdaq"))
            {
                color = "#ffFBB03B";
            }
            else if (name.Contains("Alphabet"))
            {
                color = "#ff00D009";
            }
            else if (name.Contains("Yahoo"))
            {
                color = "#ff0051A2";
            }
            else
            {
                color = "#ffF7754D";
            }

            return color;
        }
    }
}
