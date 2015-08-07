namespace _03.ComparePerformanceOfFunctions
{
    using System;

    public class SinusMethods
    {
        public static double CalculateFloatSinus(float number)
        {
            return Math.Sin(number);
        }

        public static double CalculateDoubleSinus(double number)
        {
            return Math.Sin(number);
        }

        public static double CalculateDecimalSinus(decimal number)
        {
            return Math.Sin((double)number);
        }
    }
}
