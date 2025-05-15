using Investments.Domain.Common;

namespace Investments.Domain.Tests.Common
{
    public class GuardTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(0.0001)]
        public void GreaterThanZero_Decimal_ShouldNotThrow_WhenValueIsValid(decimal value)
        {
            // Act
            Guard.GreaterThanZero(value, nameof(value));

            // Assert
            Assert.True(true);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void GreaterThanZero_Decimal_ShouldThrow_WhenValueIsInvalid(decimal value)
        {
            // Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.GreaterThanZero(value, "amount"));

            // Assert
            Assert.Equal("amount", exception.ParamName);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(999)]
        public void GreaterThanZero_Int_ShouldNotThrow_WhenValueIsValid(int value)
        {
            // Act & Assert
            Guard.GreaterThanZero(value, nameof(value));

            // Assert
            Assert.True(true);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void GreaterThanZero_Int_ShouldThrow_WhenValueIsInvalid(int value)
        {
            // Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.GreaterThanZero(value, "totalMonths"));

            // Assert
            Assert.Equal("totalMonths", exception.ParamName);
        }
    }
}
