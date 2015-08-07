namespace _03.ComparePerformanceOfFunctions
{
    using System;
    using System.Diagnostics;

    public class TestPerformance
    {
        public static void Main()
        {
            Console.WriteLine("Order of the floating types of numbers: Float, Double, Decimal.");
            Console.WriteLine("Testing natural logarithm of floating types of numbers");
            DisplayExecutionTime(() => LogMethods.CalculateFloatLog(100000.3f));
            DisplayExecutionTime(() => LogMethods.CalculateDoubleLog(100000.3));
            DisplayExecutionTime(() => LogMethods.CalculateDecimalLog(100000.3m));

            Console.WriteLine("Testing square root of floating types of numbers");
            DisplayExecutionTime(() => SqrtMethods.CalculateFloatSqrt(100000.3f));
            DisplayExecutionTime(() => SqrtMethods.CalculateDoubleSqrt(100000.3));
            DisplayExecutionTime(() => SqrtMethods.CalculateDecimalSqrt(100000.3m));

            Console.WriteLine("Testing sinus of floating types of numbers");
            DisplayExecutionTime(() => SinusMethods.CalculateFloatSinus(100000.3f));
            DisplayExecutionTime(() => SinusMethods.CalculateDoubleSinus(100000.3));
            DisplayExecutionTime(() => SinusMethods.CalculateDecimalSinus(100000.3m));
        }

        private static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}
