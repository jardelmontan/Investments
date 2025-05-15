namespace Investments.Domain.Interfaces.Services
{
    public interface IFinanceService
    {
        decimal GetCdiTax();
        decimal GetTbTax();
    }
}
