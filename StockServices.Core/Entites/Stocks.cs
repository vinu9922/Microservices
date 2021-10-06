using System;
using System.Collections.Generic;
using System.Text;

namespace StockServices.Core.Entites
{
    public class Stocks
    {
        public int StockId { get; set; }
        public int CompanyId { get; set; }
        public string ComapnyName { get; set; }
        public int StockPrice { get; set; }
    }
}
