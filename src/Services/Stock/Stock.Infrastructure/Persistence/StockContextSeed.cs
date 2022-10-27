using Microsoft.Extensions.Logging;
using Stock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Infrastructure.Persistence
{
    public class StockContextSeed
    {

        public static async Task SeedAsync(StockContext stockContext, ILogger<StockContextSeed> logger)
        {
            if (!stockContext.Stocks.Any())
            {
                stockContext.Stocks.AddRange(GetPreconfiguredOrders());
                await stockContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(StockContext).Name);
            }
        }

        private static IEnumerable<StocksModel> GetPreconfiguredOrders()
        {
            return new List<StocksModel>
            {
                new StocksModel() {CompanyCode = "C008", StockPrice = (float?)7568.98, DateTime = new DateTime(long.Parse("2-2-2019")) }
            };
        }
    }
}
