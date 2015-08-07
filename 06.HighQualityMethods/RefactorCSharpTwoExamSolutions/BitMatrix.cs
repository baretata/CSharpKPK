namespace CSharpExamTwo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class BitMatrix
    {
        public static void MainMethod()
        {
            int r;
            int c;
            ReadInitialInput(out r, out c);

            BigInteger[,] matrix = new BigInteger[r, c];
            matrix[r - 1, 0] = 1;
            FillMatrix(r, c, matrix);

            BigInteger sum = 0;
            int myRow = r - 1;
            int myCol = 0;

            int[] seq = ReadSecondaryInput();

            for (int i = 0; i < seq.Length; i++)
            {
                int coef = Math.Max(r, c);
                int code = seq[i];
                int currRow = code / coef;
                int currCol = code % coef;


                while (true)
                {
                    if (myCol < currCol)
                    {
                        sum = AddToSum(matrix, sum, myRow, myCol);
                        myCol++;
                        continue;
                    }
                    else if (myCol > currCol)
                    {
                        sum = AddToSum(matrix, sum, myRow, myCol);
                        myCol--;
                        continue;
                    }
                    else if (myCol == currCol)
                    {
                        if (myRow > currRow)
                        {
                            sum = AddToSum(matrix, sum, myRow, myCol);
                            myRow--;
                            continue;
                        }
                        else if (myRow < currRow)
                        {
                            sum = AddToSum(matrix, sum, myRow, myCol);
                            myRow++;
                            continue;
                        }
                        else if (myRow == currRow)
                        {
                            sum = AddToSum(matrix, sum, myRow, myCol);
                            break;
                        }
                    }
                }


                myRow = currRow;
                myCol = currCol;
            }

            Console.WriteLine(sum);
        }

        private static BigInteger AddToSum(BigInteger[,] matrix, BigInteger sum, int myRow, int myCol)
        {
            sum += matrix[myRow, myCol];
            matrix[myRow, myCol] = 0;
            return sum;
        }

        private static void FillMatrix(int r, int c, BigInteger[,] matrix)
        {
            for (int i = r - 1; i >= 0; i--)
            {
                for (int j = 1; j < c; j++)
                {
                    matrix[i, j] = matrix[i, j - 1] * 2;
                    if (j == c - 1 && i > 0)
                    {
                        matrix[i - 1, 0] = matrix[i, 0] * 2;
                    }
                }
            }
        }

        private static int[] ReadSecondaryInput()
        {
            int[] seq = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();
            return seq;
        }

        private static void ReadInitialInput(out int r, out int c)
        {
            r = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());
            int numOfMoves = int.Parse(Console.ReadLine());
        }
    }
}