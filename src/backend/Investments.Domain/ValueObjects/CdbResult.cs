namespace Investments.Domain.ValueObjects
{
    public class CdbResult
    {
        public decimal GrossValue { get; init; }
        public decimal NetValue { get; init; }
        public decimal TaxDiscountAmount { get; init; }
        public decimal InvestmentReturn { get; init; }
        public decimal TaxRate { get; init; }
    }
}
