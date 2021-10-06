using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SegmentServiceCore.Entities;
namespace SegmentServiceCore.Contracts
{
    public interface ISegmentService : IDisposable
    {
        Task<bool> AddNewSegment(string seg_name);
        Task<Segment> ViewAllCompanies(string seg_name);
        Task<bool> AddNewCompany(string seg_name, Company item);
    }
}
