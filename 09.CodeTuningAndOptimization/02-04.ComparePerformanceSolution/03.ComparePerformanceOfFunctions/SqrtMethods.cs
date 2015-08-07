namespace _03.ComparePerformanceOfFunctions
{
    using System;

    public class SqrtMethods
    {
        public static double CalculateFloatSqrt(float number)
        {
            return Math.Sqrt(number);
        }

        public static double CalculateDoubleSqrt(double number)
        {
            return Math.Sqrt(number);
        }

        public static double CalculateDecimalSqrt(decimal number)
        {
            return Math.Sqrt((double)number);
        }
    }
}
