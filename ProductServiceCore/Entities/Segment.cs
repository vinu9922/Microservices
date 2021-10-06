using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegmentServiceCore.Entities
{
    public class Segment
    {
        public int SegmentId { get; set; }
       
        public string SegmentName { get; set; }
        public Segment()
        {
            comp = new HashSet<Company>();
        }
        public virtual ICollection<Company> comp { get; set; }
    }
}
