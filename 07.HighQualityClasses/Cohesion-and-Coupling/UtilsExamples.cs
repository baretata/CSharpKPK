namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            TestFileUtilsMethods();

            TestCoordinateSystemMethods();

            TestCoordinateSystemUtilsMethods();
        }

        private static void TestCoordinateSystemMethods()
        {
            Console.WriteLine("Distance in the 2D space = {0:f2}", CoordinateSystem.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", CoordinateSystem.CalcDistance3D(5, 2, -1, 3, -6, 4));
        }

        private static void TestCoordinateSystemUtilsMethods()
        {
            CoordinateSystemUtils.Width = 3;
            CoordinateSystemUtils.Height = 4;
            CoordinateSystemUtils.Depth = 5;

            Console.WriteLine("Volume = {0:f2}", CoordinateSystemUtils.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", CoordinateSystemUtils.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", CoordinateSystemUtils.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", CoordinateSystemUtils.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", CoordinateSystemUtils.CalcDiagonalYZ());
        }

        private static void TestFileUtilsMethods()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));
        }
    }
}
