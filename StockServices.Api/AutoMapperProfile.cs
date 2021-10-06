using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using StockServices.Api.DTO_Class;
using StockServices.Core.Entites;

namespace StockServices.Api
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StockDTO, Stocks>().ReverseMap();
        }
    }
}
