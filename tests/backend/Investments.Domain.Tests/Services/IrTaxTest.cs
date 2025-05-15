using Investments.Domain.Services;

namespace Investments.Domain.Tests.Services
{
    public class IrTaxTest
    {
        [Theory]
        [InlineData(1000, 3, 0.225)]
        [InlineData(1000, 6, 0.225)]
        [InlineData(1000, 7, 0.20)]
        [InlineData(1000, 12, 0.20)]
        [InlineData(1000, 13, 0.175)]
        [InlineData(1000, 24, 0.175)]
        [InlineData(1000, 25, 0.15)]
        [InlineData(1000, 36, 0.15)]
        public void CalculateDiscount_ShouldReturnCorrectDiscount(decimal amount, int totalMonths, decimal expectedRate)
        {
            // Act
            var result = IrTax.CalculateDiscount(amount, totalMonths);

            // Assert
            Assert.Equal(expectedRate, result.TaxRate);
            Assert.Equal(amount * expectedRate, result.Discount);
        }

        [Theory]
        [InlineData(0, 12)]
        [InlineData(1000, 0)]
        [InlineData(0, 0)]
        public void CalculateDiscount_ShouldThrowArgumentOutOfRangeException_WhenInputIsInvalid(decimal amount, int totalMonths)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => IrTax.CalculateDiscount(amount, totalMonths));
        }
    }
}
