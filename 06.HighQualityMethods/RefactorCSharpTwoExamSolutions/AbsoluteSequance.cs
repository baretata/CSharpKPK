namespace CSharpExamTwo
{
    using System;
    using System.Linq;

    public class AbsoluteSequance
    {
        public static void MainMethod()
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 1;

            for (int i = 0; i < n; i++)
            {
                int[] seq = ReadInput();


                for (int j = 1; j < seq.Length - 1; j++)
                {
                    int prev = Math.Abs(seq[j] - seq[j - 1]);
                    int next = Math.Abs(seq[j] - seq[j + 1]);
                    if (next == prev || next == prev + 1)
                    {
                        counter++;
                    }
                    else
                    {
                        Console.WriteLine("False");
                        break;
                    }
                }

                if (counter == seq.Length - 1)
                {
                    Console.WriteLine("True");
                }
                counter = 1;

            }
        }

        private static int[] ReadInput()
        {
            int[] seq = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
            return seq;
        }
    }
}