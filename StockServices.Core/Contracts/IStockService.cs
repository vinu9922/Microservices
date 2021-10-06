using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StockServices.Core.Entites;
namespace StockServices.Core.Contracts
{
    public interface IStockService: IDisposable
    {
        Task<bool> AddStock(Stocks stock);
        Task<Stocks> FindById(int StocksId);
        Task<IEnumerable<Stocks>> ViewStocks();
    }
}
