using Investments.Domain.Common;
using Investments.Domain.Constants;
using Investments.Domain.ValueObjects;

namespace Investments.Domain.Services
{
    public static class IrTax
    {
        public static IrTaxResult CalculateDiscount(decimal amount, int totalMonths)
        {
            Guard.GreaterThanZero(amount, nameof(amount));
            Guard.GreaterThanZero(totalMonths, nameof(totalMonths));

            decimal taxRate = GetTaxRate(totalMonths);

            return new IrTaxResult
            {
                TaxRate = taxRate,
                Discount = amount * taxRate
            };
        }

        private static decimal GetTaxRate(int totalMonths) => totalMonths switch
        {
            <= 6 => TaxRates.UpTo6Months,
            <= 12 => TaxRates.UpTo12Months,
            <= 24 => TaxRates.UpTo24Months,
            _ => TaxRates.Above24Months
        };
    }
}
