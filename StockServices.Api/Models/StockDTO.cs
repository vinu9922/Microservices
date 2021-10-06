using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockServices.Api.DTO_Class
{
    public class StockDTO
    {
        [Required]
        public int StockId { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public string ComapnyName { get; set; }
        [Required]
        public int StockPrice { get; set; }
    }
}
