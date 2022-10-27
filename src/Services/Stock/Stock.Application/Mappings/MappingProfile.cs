using AutoMapper;
using Stock.Application.Features.Stocks.Command.AddStock;
using Stock.Application.Features.Stocks.Queries.GetStockListOnDate;
using Stock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StocksModel, StocksVm>().ReverseMap();
            CreateMap<StocksModel, AddStockCommand>().ReverseMap();
        }
    }
}
