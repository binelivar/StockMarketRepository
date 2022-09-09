using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Application.Features.Stocks.Queries.GetStockListOnDate
{
    public class StocksVm
    {
        public string CompanyCode { get; set; }

        public float? StockPrice { get; set; }

        public DateTime? DateTime { get; set; }
    }
}
