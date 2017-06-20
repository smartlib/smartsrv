using StockContract;
using System;
using System.Collections.Generic;

namespace StockProvider.Core
{
    public interface IStockProvider : IDisposable
    {
        string DataSource { get; }

        Interval Interval { get; }

        string Symbol { get; }

        IEnumerable<PriceData> GetData();
    }
}
