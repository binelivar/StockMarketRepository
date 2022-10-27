using Stock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Application.Contracts.Persistence
{
    public interface IStockRepository : IAsyncRepository<Domain.Entities.StocksModel>
    {
        Task<IEnumerable<Domain.Entities.StocksModel>> GetStocksByCompanyCode(string code);
    }
}
