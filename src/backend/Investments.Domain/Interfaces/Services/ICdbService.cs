using Investments.Domain.Dtos.Requests;

namespace Investments.Domain.Interfaces.Services
{
    public interface ICdbService
    {
        public SimulateCdbResponseDto SimulateInvestment(SimulateCdbRequestDto request);
    }
}
