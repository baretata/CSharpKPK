namespace _02.ComparePerformanceOfOperators
{
    using System;
    using System.Diagnostics;

    public class TestPerformance
    {
        public static void Main()
        {
            Console.WriteLine("Order of the types of numbers: Int, Long, Float, Double, Decimal.");
            Console.WriteLine("Test addition for every type of number");
            DisplayExecutionTime(() => AdditionMethods.AddInt(5, 2000000000));
            DisplayExecutionTime(() => AdditionMethods.AddLong(5L, 4000000000L));
            DisplayExecutionTime(() => AdditionMethods.AddFloat(5.0f, 100000.1f));
            DisplayExecutionTime(() => AdditionMethods.AddDouble(5, 200000.1));
            DisplayExecutionTime(() => AdditionMethods.AddDecimal(5m, 200000.1m));

            Console.WriteLine("Test subtraction for every type of number");
            DisplayExecutionTime(() => SubtractionMethods.SubtractInt(5, 2000000000));
            DisplayExecutionTime(() => SubtractionMethods.SubtractLong(5L, 4000000000L));
            DisplayExecutionTime(() => SubtractionMethods.SubtractFloat(5.0f, 100000.1f));
            DisplayExecutionTime(() => SubtractionMethods.SubtractDouble(5, 200000.1));
            DisplayExecutionTime(() => SubtractionMethods.SubtractDecimal(5m, 200000.1m));

            Console.WriteLine("Test multiplication for every type of number");
            DisplayExecutionTime(() => MultiplicationMethods.MultiplicationInt(5, 2000000000));
            DisplayExecutionTime(() => MultiplicationMethods.MultiplicationLong(5L, 4000000000L));
            DisplayExecutionTime(() => MultiplicationMethods.MultiplicationFloat(5.0f, 100000.1f));
            DisplayExecutionTime(() => MultiplicationMethods.MultiplicationDouble(5, 200000.1));
            DisplayExecutionTime(() => MultiplicationMethods.MultiplicationDecimal(5m, 200000.1m));

            Console.WriteLine("Test division for every type of number");
            DisplayExecutionTime(() => DivisionMethods.DivideInt(5, 2000000000));
            DisplayExecutionTime(() => DivisionMethods.DivideLong(5L, 4000000000L));
            DisplayExecutionTime(() => DivisionMethods.DivideFloat(5.0f, 100000.1f));
            DisplayExecutionTime(() => DivisionMethods.DivideDouble(5, 200000.1));
            DisplayExecutionTime(() => DivisionMethods.DivideDecimal(5m, 200000.1m));

            Console.WriteLine("Test incrementation for every type of number");
            DisplayExecutionTime(() => { int n = 2000000000; n++; });
            DisplayExecutionTime(() => { long n = 4000000000L; n++; });
            DisplayExecutionTime(() => { float n = 200000.1f; n++; });
            DisplayExecutionTime(() => { double n = 200000.1; n++; });
            DisplayExecutionTime(() => { decimal n = 200000.1m; n++; });
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
