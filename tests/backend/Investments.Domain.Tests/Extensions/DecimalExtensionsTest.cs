using Investments.Domain.Extensions;

namespace Investments.Domain.Tests.Extensions
{
    public class DecimalExtensionsTest
    {
        [Theory]
        [InlineData(2, 3, 8)]
        [InlineData(5, 0, 1)]
        [InlineData(10, 1, 10)]
        [InlineData(2, -2, 0.25)]
        [InlineData(1.5, 2, 2.25)]
        public void Pow_ShouldReturnExpectedResult(decimal baseValue, int exponent, double expected)
        {
            // Act
            decimal result = baseValue.Pow(exponent);

            // Assert
            Assert.InRange((double)result, expected - 0.0001, expected + 0.0001);
        }

        [Fact]
        public void Pow_WithExponentZero_ShouldReturnOne()
        {
            // Arrange
            decimal baseValue = 123.456m;

            // Act
            decimal result = baseValue.Pow(0);

            // Assert
            Assert.Equal(1, result);
        }
    }
}
