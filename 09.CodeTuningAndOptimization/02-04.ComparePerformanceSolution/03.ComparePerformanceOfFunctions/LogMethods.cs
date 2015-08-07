namespace _03.ComparePerformanceOfFunctions
{
    using System;

    public class LogMethods
    {
        public static double CalculateFloatLog(float number)
        {
            return Math.Log(number);
        }

        public static double CalculateDoubleLog(double number)
        {
            return Math.Log(number);
        }

        public static double CalculateDecimalLog(decimal number)
        {
            return Math.Log((double)number);
        }
    }
}
