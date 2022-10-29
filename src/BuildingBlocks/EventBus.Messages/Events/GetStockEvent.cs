using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events 
{
    public class GetStockEvent : IntegrationBaseEvent
    {
        public string CompanyCode { get; set; }

        public string? CompanyName { get; set; }

        public string? CompanyCEO { get; set; }

        public float? CompanyTurnOver { get; set; }

        public string? CompanyWebsite { get; set; }

        public string? StockExchange { get; set; }

        public float? StockPrice { get; set; }

        public DateTime? DateTime { get; set; }
    }
}
