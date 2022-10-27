using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Stock.Application.Contracts.Persistence;
using Stock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stock.Application.Features.Stocks.Command.AddStock
{
    public class AddStockCommandHandler : IRequestHandler<AddStockCommand, int>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddStockCommandHandler> _logger;

        public AddStockCommandHandler(IStockRepository stockRepository, IMapper mapper, ILogger<AddStockCommandHandler> logger)
        {
            _stockRepository = stockRepository ?? throw new ArgumentNullException(nameof(stockRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(AddStockCommand request, CancellationToken cancellationToken)
        {
            var stockEntity = _mapper.Map<StocksModel>(request);
            var newStock = await _stockRepository.AddAsync(stockEntity);

            _logger.LogInformation($"Order {newStock.Id} is successfully created.");

            return newStock.Id;
        }
    }
}
