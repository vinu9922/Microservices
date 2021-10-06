using AutoMapper;
using SegmentServiceApi.Model;
using SegmentServiceCore.Entities;
using SegmentServiceCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegmentServiceApi
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Segment , SegmentDTO>().ReverseMap();
            CreateMap<Company, CompanyDTO>().ReverseMap();
        }
    }
}
