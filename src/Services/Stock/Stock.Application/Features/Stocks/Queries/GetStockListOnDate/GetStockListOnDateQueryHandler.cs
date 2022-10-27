using AutoMapper;
using MediatR;
using Stock.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stock.Application.Features.Stocks.Queries.GetStockListOnDate
{
    public class GetStockListOnDateQueryHandler : IRequestHandler<GetStockListOnDateQuery, List<StocksVm>>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public GetStockListOnDateQueryHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository ?? throw new ArgumentNullException(nameof(stockRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<StocksVm>> Handle(GetStockListOnDateQuery request,
            CancellationToken cancellationToken)
        {
            var orderList = await _stockRepository.GetStocksByCompanyCode(request.CompanyCode);
            return _mapper.Map<List<StocksVm>>(orderList);
        }
    }
}
