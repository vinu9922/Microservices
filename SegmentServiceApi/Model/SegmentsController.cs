using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class SegmentsController : ControllerBase ,IDisposable
    {
        private readonly AddSegmentServices seg_service;
        private readonly IMapper mapper;

        public SegmentsController(AddSegmentServices seg_service)
        {
            this.seg_service = seg_service;
        }
        public void Dispose()
        {
            seg_service.Dispose();
        }
        [HttpGet("{seg_id}")]
        [ProducesResponseType(200,Type =typeof(SegmentDTO))]
        public async Task<ActionResult<SegmentDTO>> ListCompanies(int seg_id)
        {
            var S1 = await seg_service.ViewAllCompanies(seg_id);
            var Dto = mapper.Map<SegmentDTO>(S1);
            return Ok(Dto);
        }

        [HttpPost("{seg_id}")]
        [Consumes("application/json")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddCompany(int seg_id, CompanyDTO comdto)
        {
            var SegmentItemObj = mapper.Map<Company>(comdto);
            await seg_service.AddNewCompany(seg_id, SegmentItemObj);
            return StatusCode(201);
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddSegment(SegmentDTO seg_dto)
        {
            var SegmentItemObj = mapper.Map<Segment>(seg_dto);
            await seg_service.AddNewSegment(SegmentItemObj);
            return StatusCode(201);
        }



    }
}
