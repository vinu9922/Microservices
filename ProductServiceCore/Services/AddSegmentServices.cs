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
        public async Task<bool> AddNewCompany(int seg_id,Company item)
        {
            var checkSegment = await segmentrepo.GetAync(obj => obj.SegmentId == seg_id, "comp");
            Segment UserSegment = checkSegment.FirstOrDefault();
            if (UserSegment == null)
            {
                /* UserSegment = new Segment();
                 UserSegment.SegmentName = seg_name;
                 segmentrepo.Add(UserSegment);*/
                //AddNewSegment();
            }
            else
            {
                // UserSegment
                segmentrepo.Update(UserSegment);
            }
            UserSegment.comp.Add(item);
            var Rows = await segmentrepo.SaveAsync();

            return Rows > 0;
        }

        public async Task<bool> AddNewSegment( Segment seg)
        {
            if (seg.SegmentName==null)
            {
                throw new ArgumentException("invalid segment name");
            }
            segmentrepo.Add(seg);
            int Rows= await segmentrepo.SaveAsync();
            return Rows > 0;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ViewAllCompanies(int seg_id)
        {
            var seg_items = await segmentrepo.GetAync(obj => obj.SegmentId == seg_id, "comp");
            return seg_items.FirstOrDefault();
        }
    }
}
