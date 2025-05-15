using Investments.Domain.Interfaces.Services;

namespace Investments.Application.Services
{
    public class FinanceService : IFinanceService
    {
        public decimal GetCdiTax() => 0.009m;

        public decimal GetTbTax() => 1.08m;
    }
}
