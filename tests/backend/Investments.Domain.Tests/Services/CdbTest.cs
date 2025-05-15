using Investments.Domain.Services;

namespace Investments.Domain.Tests.Services
{
    public class CdbTest
    {
        [Fact]
        public void SimulateInvestment_ShouldReturnExpectedResult_WhenInputIsValid()
        {
            // Arrange
            decimal initialAmount = 1000m;
            int totalMonths = 12;
            decimal cdiTax = 0.013m;
            decimal tbTax = 1.0m;

            // Act
            var result = Cdb.SimulateInvestment(initialAmount, totalMonths, cdiTax, tbTax);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.GrossValue > initialAmount);
            Assert.True(result.NetValue < result.GrossValue);

            decimal expectedReturn = result.GrossValue - initialAmount;
            Assert.InRange(result.InvestmentReturn, expectedReturn - 0.01m, expectedReturn + 0.01m);

            decimal expectedDiscount = result.GrossValue - result.NetValue;
            Assert.InRange(result.TaxDiscountAmount, expectedDiscount - 0.01m, expectedDiscount + 0.01m);
        }

        [Theory]
        [InlineData(0, 12, 0.013, 1.0)]
        [InlineData(1000, 0, 0.013, 1.0)]
        [InlineData(1000, 12, 0.0, 1.0)]
        [InlineData(1000, 12, 0.013, 0.0)]
        public void SimulateInvestment_ShouldThrowArgumentOutOfRangeException_WhenInputIsInvalid(
            decimal initialAmount,
            int totalMonths,
            decimal cdiTax,
            decimal tbTax)
        {
            // Act
            void act() => Cdb.SimulateInvestment(initialAmount, totalMonths, cdiTax, tbTax);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(act);
        }
    }
}
