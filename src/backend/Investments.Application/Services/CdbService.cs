using Investments.Domain.Dtos.Requests;
using Investments.Domain.Interfaces.Services;
using Investments.Domain.Services;

namespace Investments.Application.Services
{
    public class CdbService(IFinanceService financeService) : ICdbService
    {
        private readonly IFinanceService _financeService = financeService;

        public SimulateCdbResponseDto SimulateInvestment(SimulateCdbRequestDto request)
        {
            var cdiTax = _financeService.GetCdiTax();
            var tbTax = _financeService.GetTbTax();

            var result = Cdb.SimulateInvestment(request.InitialAmount, request.TotalMonths, cdiTax, tbTax);

            var grossValue = Math.Round(result.GrossValue, 2);
            var netValue = Math.Round(result.NetValue, 2);
            var taxDiscountAmount = grossValue - netValue;

            return new SimulateCdbResponseDto
            {
                GrossValue = grossValue,
                NetValue = netValue,
                TaxDiscountAmount = taxDiscountAmount,
                InvestmentReturn = Math.Round(result.InvestmentReturn, 2),
                TaxRate = result.TaxRate
            };
        }
    }
}
