using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegmentServiceApi.Model
{
    public class SegmentDTO
    {
        public int SegmentId { get; set; }

        public string SegmentName { get; set; }
       
        public  IEnumerable<CompanyDTO> Comp { get; set; }
    }
}
