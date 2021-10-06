using SegmentServiceCore.Contracts;
using SegmentServiceCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegmentServiceCore.Services
{   
    public class AddSegmentServices : ISegmentService
    {
        private readonly IRepository<Segment> segmentrepo;
        public AddSegmentServices(IRepository<Segment> segmentrepo)
        {
            this.segmentrepo = segmentrepo;
        }
        public async Task<bool> AddNewCompany(string seg_name,Company item)
        {
            var checkSegment = await segmentrepo.GetAync(obj => obj.SegmentName == seg_name, "comp");
            Segment UserSegment = checkSegment.FirstOrDefault();
            if (UserSegment == null)
            {
                 UserSegment = new Segment();
                 UserSegment.SegmentName = seg_name;
                 segmentrepo.Add(UserSegment);
               
            }
            else
            {
                
                segmentrepo.Update(UserSegment);
            }
            UserSegment.comp.Add(item);
            var Rows = await segmentrepo.SaveAsync();

            return Rows > 0;
        }

        public async Task<bool> AddNewSegment( string seg_name)
        {
            
            var UserSegment = new Segment();
            UserSegment.SegmentName = seg_name;
            segmentrepo.Add(UserSegment);
            
            int Rows= await segmentrepo.SaveAsync();
            return Rows > 0;
        }

        public void Dispose()
        {
            segmentrepo.Dispose();
        }

        public async Task<Segment> ViewAllCompanies(string seg_name)
        {
            var seg_items = await segmentrepo.GetAync(obj => obj.SegmentName == seg_name, "comp");
            return seg_items.FirstOrDefault();
        }
    }
}
