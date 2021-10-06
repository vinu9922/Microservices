using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SegmentServiceCore.Contracts;
using SegmentServiceCore.Entities;
using SegmentServiceCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegmentServiceApi.Model
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentsController : ControllerBase, IDisposable
    {
        private readonly ISegmentService seg_service;
        private readonly IMapper mapper;

       
        public SegmentsController(ISegmentService seg_service, IMapper mapper)
        {
            this.seg_service = seg_service;
            this.mapper = mapper;
        }
        public void Dispose()
        {
            seg_service.Dispose();
        }
        [HttpGet("{seg_name}")]
        [ProducesResponseType(200,Type =typeof(SegmentDTO))]
        public async Task<ActionResult<SegmentDTO>> ListCompanies(string seg_name)
        {
            var S1 = await seg_service.ViewAllCompanies(seg_name);
            var Dto = mapper.Map<SegmentDTO>(S1);
            return Ok(Dto);
        }

        [HttpPost("{seg_name}")]
        [Consumes("application/json")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddCompany(string seg_name, CompanyDTO comdto)
        {
            var CompanyItemObj = mapper.Map<Company>(comdto);
            await seg_service.AddNewCompany(seg_name, CompanyItemObj);
            return StatusCode(201);
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddSegment(string seg_name)
        {
            //var SegmentItemObj = mapper.Map<Segment>(seg_dto);
            await seg_service.AddNewSegment(seg_name);
            return StatusCode(201);
        }



    }
}
