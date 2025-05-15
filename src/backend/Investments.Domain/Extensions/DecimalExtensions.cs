namespace Investments.Domain.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal Pow(this decimal baseValue, int exponent)
        {
            if (exponent == 0)
            {
                return 1;
            }

            decimal result = 1;

            for (int i = 0; i < Math.Abs(exponent); i++)
            {
                result *= baseValue;
            }

            return exponent < 0 ? 1 / result : result;
        }
    }
}
