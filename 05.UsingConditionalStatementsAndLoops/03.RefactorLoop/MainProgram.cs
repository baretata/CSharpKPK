namespace _03.RefactorLoop
{
    using System;

    public class MainProgram
    {
        public static void Main()
        {
            int[] array = new int[100];
            int currentValue = 0;
            int expectedValue = 666;
            for (int i = 0; i < array.Length; i++)
            {
                currentValue = i;
                if (currentValue % 10 == 0)
                {
                    Console.WriteLine(array[currentValue]);
                    if (array[currentValue] == expectedValue)
                    {
                        currentValue = 666;
                    }
                }
                else
                {
                    Console.WriteLine(array[currentValue]);
                }
            }

            // More code here
            if (currentValue == 666)
            {
                Console.WriteLine("Value Found");
            }

        }
    }
}
