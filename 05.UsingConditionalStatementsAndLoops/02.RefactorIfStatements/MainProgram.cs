namespace _02.RefactorIfStatements
{
    using System;

    public class MainProgram
    {
        public static void Main()
        {
            // Potato problem
            Potato potato = new Potato();
            if (potato != null && (potato.HasBeenPeeled && potato.IsNotRotten))
            {
                Potato.Cook(potato);
            }

            // Matrix visited cell problem
            CheckViableCell();
        }

        public static void CheckViableCell()
        {
            int x = 0;
            int y = 0;
            int minX = 0;
            int minY = 0;
            int maxX = 0;
            int maxY = 0;

            bool shouldVisitCell = true;
            bool xCoordValidator = (x >= minX) && (x <= maxX);
            bool yCoorValodator = (y >= minY) && (y <= maxY);

            if ((xCoordValidator && yCoorValodator) && shouldVisitCell)
            {
               VisitCell();
            }
        }

        public static void VisitCell()
        { 
        }
    }
}
