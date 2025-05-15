namespace Investments.Domain.Common
{
    public static class Guard
    {
        public static void GreaterThanZero(decimal value, string paramName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(paramName, $"{paramName} must be greater than zero.");
            }
        }

        public static void GreaterThanZero(int value, string paramName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(paramName, $"{paramName} must be greater than zero.");
            }
        }
    }
}
