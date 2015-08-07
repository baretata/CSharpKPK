namespace Methods
{
    using System;

    public class MainProgram
    {
        public static void Main()
        {
            Console.WriteLine(MathUtils.CalcTriangleArea(3, 4, 5));

            Console.WriteLine(MathUtils.DigitToString(5));

            Console.WriteLine(MathUtils.FindMax(5, -1, 3, 2, 14, 2, 3));

            MathUtils.FormatNumber(1.3, "f");
            MathUtils.FormatNumber(0.75, "%");
            MathUtils.FormatNumber(2.30, "r");

            Console.WriteLine(MathUtils.CalcDistance(3, -1, 3, 2.5));

            Console.WriteLine("Horizontal? - {0}", MathUtils.IsHorizontal(3, -1));
            Console.WriteLine("Vertical? - {0}", MathUtils.IsVertical(3, 2.5));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
