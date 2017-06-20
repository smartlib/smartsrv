using StockProvider.Core;
using System;

namespace ImportProvider.core
{
    public interface IImportProvider : IDisposable
    {
        void Import(IStockProvider data);
    }
}
