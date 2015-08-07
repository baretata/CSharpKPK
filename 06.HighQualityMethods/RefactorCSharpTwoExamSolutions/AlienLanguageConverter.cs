namespace CSharpExamTwo
{
    using System;
    using System.Collections.Generic;

    public class AlienLanguageConverter
    {
        public static void MainMethod()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            long sum = 0;
            var inHumanLanguage = new List<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char[] charArr = input[i].ToCharArray();

                sum = ConvertChars(sum, charArr);

                sum = DecypherChars(sum, inHumanLanguage);

                inHumanLanguage.Reverse();

                PrintResult(inHumanLanguage);

                inHumanLanguage.Clear();
            }

        }

        private static long ConvertChars(long sum, IEnumerable<char> charArr)
        {
            foreach (char ch in charArr)
            {
                sum *= 21;
                sum += (ch - 'a');
            }

            return sum;
        }

        private static void PrintResult(IEnumerable<char> inHumanLanguage)
        {
            foreach (var item in inHumanLanguage)
            {
                Console.Write(item);
            }
            Console.Write(" ");
        }

        private static long DecypherChars(long sum, IList<char> inHumanLanguage)
        {
            do
            {
                long remainder = sum % 26;
                char real = (char)(remainder + 'a');
                inHumanLanguage.Add(real);
                sum /= 26;
            }
            while (sum > 0);
            
            return sum;
        }
    }
}