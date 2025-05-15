using FluentValidation;
using Investments.Domain.Dtos.Requests;

namespace Investments.WebApi.Validators.SimulateInvestment
{
    public class SimulateCdbValidator : AbstractValidator<SimulateCdbRequestDto>
    {
        public SimulateCdbValidator()
        {
            RuleFor(x => x.InitialAmount)
                .GreaterThan(0).WithMessage("Initial amount must be greater than zero.");

            RuleFor(x => x.TotalMonths)
               .GreaterThan(1).WithMessage("Total months must be greater than 1.");
        }
    }
}
