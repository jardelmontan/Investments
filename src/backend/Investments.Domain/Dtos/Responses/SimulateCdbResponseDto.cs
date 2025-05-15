namespace Investments.Domain.Dtos.Requests
{
    public class SimulateCdbResponseDto
    {
        public decimal GrossValue { get; set; }
        public decimal NetValue { get; set; }
        public decimal TaxDiscountAmount { get; set; }
        public decimal InvestmentReturn { get; set; }
        public decimal TaxRate { get; set; }
    }
}


