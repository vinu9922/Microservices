using System;
using System.Collections.Generic;
using System.Text;

namespace SegmentServiceCore.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string ComapnyName { get; set; }
        public int Date { get; set; }
        public int StockPriceToday { get; set; }
        public int StockId { get; set; }
        public virtual Segment segment { get; set; }
    }
}
