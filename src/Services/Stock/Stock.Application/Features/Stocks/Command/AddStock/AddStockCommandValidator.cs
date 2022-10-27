using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Application.Features.Stocks.Command.AddStock
{
    public class AddStockCommandValidator : AbstractValidator<AddStockCommand>
    {
        public AddStockCommandValidator()
        {
            RuleFor(p => p.CompanyCode)
                .NotEmpty().WithMessage("{CompanyCode} is required.")
                .NotNull()
                .MaximumLength(10).WithMessage("{CompanyCode} must not exceed 10 characters.");

            RuleFor(p => p.StockPrice)
                .NotEmpty().WithMessage("{StockPrice} is required.")
                .GreaterThan(0).WithMessage("{StockPrice} should be greater than zero.");
        }
    }
}
