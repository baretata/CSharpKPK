namespace RefactorVariable
{
    using System;

    public class Statistics
    {
        public void PrintStatistics(double[] arr, int count)
        {
            double maxValue = 0;

            for (int i = 0; i < count; i++)
            {
                if (arr[i] > maxValue)
                {
                    maxValue = arr[i];
                }
            }

            this.PrintMaxValue(maxValue);

            double minValue = 0;

            for (int i = 0; i < count; i++)
            {
                if (arr[i] < minValue)
                {
                    minValue = arr[i];
                }
            }

            this.PrintMinValue(minValue);

            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += arr[i];
            }

            this.PrintAvgValue(sum, count);
        }

        private void PrintAvgValue(double sum, int count)
        {
            var average = sum / count;
            Console.WriteLine(average);
        }

        private void PrintMaxValue(double maxValue)
        {
            Console.WriteLine(maxValue);
        }

        private void PrintMinValue(double minValue)
        {
            Console.WriteLine(minValue);
        }
    }
}
