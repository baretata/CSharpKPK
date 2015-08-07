namespace Methods
{
    using System;

    public class MathUtils
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }

            double perimeter = (a + b + c) / 2;
            double area = Math.Sqrt(perimeter * (perimeter - a) * (perimeter - b) * (perimeter - c));

            return area;
        }

        public static string DigitToString(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentOutOfRangeException("Invalid number!");
            }
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Invalid input entered!");
            }

            int maxValue = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxValue)
                {
                    maxValue = elements[i];
                }
            }

            return maxValue;
        }

        public static void FormatNumber(object number, string format)
        {
            if (!IsNumber(number))
            {
                throw new ArgumentException("Input is not in the correct format");
            }

            if (format == "f")
            {
                PrintNumber("{0:f2}", number);
            }
            else if (format == "%")
            {
                PrintNumber("{0:p0}", number);
            }
            else if (format == "r")
            {
                PrintNumber("{0,8}", number);
            }
            else
            {
                throw new ArgumentException("Wrong format!");
            }
        }

        public static void PrintNumber(string inputString, object number)
        {
            Console.WriteLine(inputString, number);
        }

        public static bool IsHorizontal(double y1, double y2)
        {
            return y1 == y2;
        }

        public static bool IsVertical(double x1, double x2)
        {
            return x1 == x2;
        }

        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distanceX = (x2 - x1) * (x2 - x1);
            double distanceY = (y2 - x1) * (y2 - x1);
            double distance = Math.Sqrt(distanceX + distanceY);

            return distance;
        }

        private static bool IsNumber(object number)
        {
            double n;
            string numberString = number.ToString();
            bool isNumeric = double.TryParse(numberString, out n);
            return isNumeric;
        }
    }
}
