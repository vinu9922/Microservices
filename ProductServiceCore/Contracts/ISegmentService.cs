using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SegmentServiceCore.Entities;
namespace SegmentServiceCore.Contracts
{
    public interface ISegmentService: IDisposable 
    {
        Task<bool> AddNewSegment(Segment seg);
        Task<bool> ViewAllCompanies(int seg_id);
        Task<bool> AddNewCompany(int seg_id, Company item);
    }
}
