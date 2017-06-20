using StockProvider.Core;
using System;
using StockContract;
using System.Collections.Generic;

namespace StockProvider.CSV
{
    public class CsvProvider : IStockProvider
    {
        private string _fileName;

        public CsvProvider(string fileName)
        {
            _fileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
        }

        public string FileName
        {
            get
            {
                if (_fileName == null) throw new ObjectDisposedException(nameof(FileName));
                return _fileName;
            }
        }

        public string DataSource => "CSV";

        public Interval Interval => throw new NotImplementedException();

        public string Symbol => throw new NotImplementedException();

        public void Dispose()
        {
            _fileName = null;
        }

        public IEnumerable<PriceData> GetData()
        {
            throw new NotImplementedException();
        }
    }
}
