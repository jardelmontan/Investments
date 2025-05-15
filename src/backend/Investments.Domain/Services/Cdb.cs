using Investments.Domain.Common;
using Investments.Domain.Extensions;
using Investments.Domain.ValueObjects;

namespace Investments.Domain.Services
{
    public static class Cdb
    {

        public static CdbResult SimulateInvestment(decimal initialAmount, int totalMonths, decimal cdiTax, decimal tbTax)
        {
            Guard.GreaterThanZero(initialAmount, nameof(initialAmount));
            Guard.GreaterThanZero(totalMonths, nameof(totalMonths));
            Guard.GreaterThanZero(cdiTax, nameof(cdiTax));
            Guard.GreaterThanZero(tbTax, nameof(tbTax));

            decimal monthTax = cdiTax * tbTax;
            decimal grossValue = initialAmount * (1 + monthTax).Pow(totalMonths);
            decimal investmentReturn = grossValue - initialAmount;

            var irTaxResult = IrTax.CalculateDiscount(investmentReturn, totalMonths);

            decimal netValue = grossValue - irTaxResult.Discount;

            return new CdbResult
            {
                GrossValue = grossValue,
                NetValue = netValue,
                InvestmentReturn = investmentReturn,
                TaxDiscountAmount = irTaxResult.Discount,
                TaxRate = irTaxResult.TaxRate
            };
        }
    }
}
