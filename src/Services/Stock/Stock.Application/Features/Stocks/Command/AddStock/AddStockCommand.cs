using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Application.Features.Stocks.Command.AddStock
{
    public class AddStockCommand : IRequest<int>
    {
        public string CompanyCode { get; set; }

        public float? StockPrice { get; set; }

        public DateTime? DateTime { get; set; }
    }
}
