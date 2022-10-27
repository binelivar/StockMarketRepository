using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stock.Application.Features.Stocks.Command.AddStock;
using Stock.Application.Features.Stocks.Queries.GetStockListOnDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Stock.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{companyCode}", Name = "GetStock")]
        [ProducesResponseType(typeof(IEnumerable<StocksVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<StocksVm>>> GetStockByCode(string companyCode)
        {
            var query = new GetStockListOnDateQuery(companyCode);
            var stocks = await _mediator.Send(query);
            return Ok(stocks);
        }

        // testing purpose
        [HttpPost(Name = "AddStock")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> AddStock([FromBody] AddStockCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
