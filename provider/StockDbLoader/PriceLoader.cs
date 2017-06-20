using ImportProvider.core;
using System;
using StockProvider.Core;
using Data;
using System.Linq;

namespace StockDbLoader
{
    public class PriceLoader : IImportProvider
    {
        public void Dispose()
        {

        }

        public void Import(IStockProvider data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            using (var db = new StockDbContext())
            {
                using (var tran = db.Database.BeginTransaction())
                {
                    var ds = db.DataSource.FirstOrDefault(x => x.Code == data.DataSource);
                    if (ds == null) throw new NullReferenceException($"datasource {data.DataSource} is not registered");

                    var interval = db.Interval.FirstOrDefault(x => x.TimeSpan == (long)data.Interval);
                    if (interval == null) throw new NullReferenceException($"interval {data.Interval} is not registered");

                    var symbol = db.Symbol.FirstOrDefault(x => x.Code == data.Symbol);
                    if (symbol == null) throw new NullReferenceException($"symbol {data.Symbol} is not registered");

                    var importData = db.ImportData.FirstOrDefault(x =>
                    x.DataSourceCode == ds.Code
                    && x.IntervalCode == interval.Code
                    && x.SymbolCode == symbol.Code);

                    if (importData == null)
                    {
                        importData = new ImportData()
                        {
                            DataSourceCode = ds.Code,
                            IntervalCode = interval.Code,
                            SymbolCode = symbol.Code,
                            TableName = $"{symbol.Code}_{interval.Code}_{ds.Code}",
                        };
                        db.ImportData.Add(importData);
                        db.SaveChanges();
                    }

                    var history = new ImportDataHistory()
                    {

                    };

                    tran.Commit();
                }
            }
        }
    }
}
