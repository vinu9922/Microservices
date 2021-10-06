using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockServices.Api.DTO_Class;
using StockServices.Core.Contracts;
using StockServices.Core.Entites;
using StockServices.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase,IDisposable
    {
        private readonly IStockService stockservice;

        private readonly IMapper mapper;

        public StocksController (IStockService stockservice, IMapper mapper)
        {
            this.stockservice = stockservice;
            this.mapper = mapper;
        }

        public void Dispose()
        {
            stockservice.Dispose();
        }

        [HttpGet]
       
        [Produces(typeof(IEnumerable<StockDTO>))]
        [ProducesResponseType(201, Type=typeof(IEnumerable<StockDTO>))]
        public async Task<ActionResult<IEnumerable<StockDTO>>> GetStocks()
        {
            var S1 = await stockservice.ViewStocks();
            var DTOs = mapper.Map<IEnumerable<StockDTO>>(S1);
            return Ok(DTOs);
        }

        //
        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StockDTO>))]
        public async Task<ActionResult<IEnumerable<StockDTO>>> GetStocksById(int Id)
        {
            var S1 = await stockservice.FindById(Id);
            if(S1==null)
            {
                return NotFound();
            }
            var DTOs = mapper.Map<IEnumerable<StockDTO>>(S1);
            return Ok(DTOs);
        }


        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(201)]
        public async Task<ActionResult> PostStock(StockDTO model)
        {
            var s1 = mapper.Map<Stocks>(model);
            await stockservice.AddStock(s1);
            return StatusCode(201);
        }

    }
}
