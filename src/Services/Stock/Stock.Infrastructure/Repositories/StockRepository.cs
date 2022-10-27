using Microsoft.EntityFrameworkCore;
using Stock.Application.Contracts.Persistence;
using Stock.Domain.Entities;
using Stock.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Infrastructure.Repositories
{
    public class StockRepository : RepositoryBase<StocksModel>, IStockRepository
    {
        public StockRepository(StockContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<StocksModel>> GetStocksByCompanyCode(string companyCode)
        {
            var stocksList = await _dbContext.Stocks
                                    .Where(o => o.CompanyCode == companyCode)
                                    .ToListAsync();
            return stocksList;
        }
    }
}
