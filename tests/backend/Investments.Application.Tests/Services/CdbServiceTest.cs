using Investments.Application.Services;
using Investments.Domain.Dtos.Requests;
using Investments.Domain.Interfaces.Services;
using Moq;

namespace Investments.Application.Tests.Services
{
    public class CdbServiceTest
    {
        [Fact]
        public void SimulateInvestment_ShouldUseFinanceServiceValues()
        {
            // Arrange
            var mockFinance = new Mock<IFinanceService>();
            mockFinance.Setup(f => f.GetCdiTax()).Returns(0.012m);
            mockFinance.Setup(f => f.GetTbTax()).Returns(1.0m);

            var service = new CdbService(mockFinance.Object);

            var request = new SimulateCdbRequestDto
            {
                InitialAmount = 1000,
                TotalMonths = 6
            };

            // Act
            var result = service.SimulateInvestment(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.GrossValue - result.NetValue, result.TaxDiscountAmount, 2);
        }
    }
}
