using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockServices.Core.Contracts;
using StockServices.Core.Entites;

namespace StockServices.Core.Services
{
    public class StockService : IStockService
    {
        private readonly IRepository<Stocks> stocksrepository;

        public StockService(IRepository<Stocks> stocksrepository)
        {
            this.stocksrepository = stocksrepository;
        }

        public async Task<bool> AddStock(Stocks stock)
        {
            if (stock.StockPrice <= 0)
            {
                throw new ArgumentException("invalid stock price");
            }
            stocksrepository.Add(stock);
            int Rows = await stocksrepository.SaveAsync();
            return Rows > 0;
            

        }

        public void Dispose()
        {
            stocksrepository.Dispose();
        }

        public async Task<Stocks> FindById(int stock_id)
        {
            var stock = await stocksrepository.GetAsync(p => p.StockId == stock_id);
            return stock.FirstOrDefault();
        }

        public async Task<IEnumerable<Stocks>> ViewStocks()
        {
            return await stocksrepository.GetAsync();
        }
    }
}
