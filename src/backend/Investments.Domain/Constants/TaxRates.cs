using System.Diagnostics.CodeAnalysis;

namespace Investments.Domain.Constants
{
    [ExcludeFromCodeCoverage]
    public static class TaxRates
    {
        public const decimal UpTo6Months = 0.225m;
        public const decimal UpTo12Months = 0.20m;
        public const decimal UpTo24Months = 0.175m;
        public const decimal Above24Months = 0.15m;
    }
}
