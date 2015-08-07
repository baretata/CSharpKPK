namespace _04.ComparePerformanceOfSorting
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class SortingTest
    {
        public static void Main()
        {
            SelectionSorting.SelectionSortArray();
            InsertionSorting.InsertionSortArray();
            QuickSorting.QuickSortArray();
        }

        public static int[] GenerateRandomArray()
        {
            Random randomGenerator = new Random();
            int[] array = new int[100];
            for (int count = 0; count < 100; count++)
            {
                array[count] = randomGenerator.Next(count, 1000000);
            }

            return array;
        }

        public static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}
