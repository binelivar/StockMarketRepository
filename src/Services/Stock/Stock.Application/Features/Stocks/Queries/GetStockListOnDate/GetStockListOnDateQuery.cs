using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Application.Features.Stocks.Queries.GetStockListOnDate
{
    public class GetStockListOnDateQuery : IRequest<List<StocksVm>>
    {
        public string CompanyCode { get; set; }

    public GetStockListOnDateQuery(string companyCode)
    {
        CompanyCode = companyCode ?? throw new ArgumentNullException(nameof(companyCode));
    }
}
{
    }
}
