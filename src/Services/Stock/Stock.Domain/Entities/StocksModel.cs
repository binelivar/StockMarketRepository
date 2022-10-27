using Stock.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain.Entities
{
    public class StocksModel : EntityBase
    {
        public string CompanyCode { get; set; }

        public float? StockPrice { get; set; }

        public DateTime? DateTime { get; set; }
    }
}
