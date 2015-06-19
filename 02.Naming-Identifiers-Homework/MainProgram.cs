namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Mine
    {
        public static void Main()
        {
            string command = string.Empty;
            char[,] field = CreateGameField();
            char[,] bombs = CreateBombs();
            int points = 0;
            bool isDead = false;
            List<Player> highscores = new List<Player>(6);
            int row = 0;
            int column = 0;
            bool isGameStarted = true;
            const int MaxScore = 35;
            bool isGameCompleted = false;

            do
            {
                if (isGameStarted)
                {
                    Console.WriteLine("Lets play a game of “Minesweeper”. Try to find the fields without mines in them." +
                    " command 'top' shows the highscore list, 'restart' starts new game, 'exit' exits the application!");
                    DrawGameField(field);
                    isGameStarted = false;
                }

                Console.Write("Type row and column: ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out column) &&
                        row <= field.GetLength(0) && column <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        CreateHighscoreList(highscores);
                        break;
                    case "restart":
                        field = CreateGameField();
                        bombs = CreateBombs();
                        DrawGameField(field);
                        isDead = false;
                        isGameStarted = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye!");
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                PlayerTurn(field, bombs, row, column);
                                points++;
                            }

                            if (MaxScore == points)
                            {
                                isGameCompleted = true;
                            }
                            else
                            {
                                DrawGameField(field);
                            }
                        }
                        else
                        {
                            isDead = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nInvalid command!\n");
                        break;
                }

                if (isDead)
                {
                    DrawGameField(bombs);
                    Console.Write("\nHrrrrrr! You died with {0} points. " + "Type your nickname: ", points);
                    string nickname = Console.ReadLine();
                    Player playerPoints = new Player(nickname, points);

                    if (highscores.Count < 5)
                    {
                        highscores.Add(playerPoints);
                    }
                    else
                    {
                        for (int i = 0; i < highscores.Count; i++)
                        {
                            if (highscores[i].Points < playerPoints.Points)
                            {
                                highscores.Insert(i, playerPoints);
                                highscores.RemoveAt(highscores.Count - 1);
                                break;
                            }
                        }
                    }

                    highscores.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Name.CompareTo(firstPlayer.Name));
                    highscores.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Points.CompareTo(firstPlayer.Points));
                    CreateHighscoreList(highscores);

                    field = CreateGameField();
                    bombs = CreateBombs();
                    points = 0;
                    isDead = false;
                    isGameStarted = true;
                }

                if (isGameCompleted)
                {
                    Console.WriteLine("\nBRAVO! You opened 35 cells without dying.");
                    DrawGameField(bombs);
                    Console.WriteLine("Daj si imeto, batka: ");

                    string name = Console.ReadLine();
                    Player currentPlayer = new Player(name, points);

                    highscores.Add(currentPlayer);
                    CreateHighscoreList(highscores);
                    field = CreateGameField();
                    bombs = CreateBombs();
                    points = 0;
                    isGameCompleted = false;
                    isGameStarted = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria!");
            Console.WriteLine("Goodbye!");
            Console.Read();
        }

        private static void CreateHighscoreList(List<Player> highscorePoints)
        {
            Console.WriteLine("Highscores:");

            if (highscorePoints.Count > 0)
            {
                for (int i = 0; i < highscorePoints.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells", i + 1, highscorePoints[i].Name, highscorePoints[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No highscore!\n");
            }
        }

        private static void PlayerTurn(char[,] field, char[,] bombs, int row, int column)
        {
            char bombsCount = GenerateBombs(bombs, row, column);
            bombs[row, column] = bombsCount;
            field[row, column] = bombsCount;
        }

        private static void DrawGameField(char[,] board)
        {
            int row = board.GetLength(0);
            int col = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < row; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < col; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] CreateBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] gameField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            List<int> mines = new List<int>();

            while (mines.Count < 15)
            {
                Random random = new Random();
                int minePositionGenerator = random.Next(50);

                if (!mines.Contains(minePositionGenerator))
                {
                    mines.Add(minePositionGenerator);
                }
            }

            foreach (int mine in mines)
            {
                int kol = mine / cols;
                int row = mine % cols;

                if (row == 0 && mine != 0)
                {
                    kol--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                gameField[kol, row - 1] = '*';
            }

            return gameField;
        }

        private static void CalculateCellAssignment(char[,] field)
        {
            int col = field.GetLength(0);
            int row = field.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char cellAssignment = GenerateBombs(field, i, j);
                        field[i, j] = cellAssignment;
                    }
                }
            }
        }

        private static char GenerateBombs(char[,] board, int row, int col)
        {
            int bombsCount = 0;
            int maxRow = board.GetLength(0);
            int maxCol = board.GetLength(1);

            if (row - 1 >= 0)
            {
                if (board[row - 1, col] == '*')
                {
                    bombsCount++;
                }
            }

            if (row + 1 < maxRow)
            {
                if (board[row + 1, col] == '*')
                {
                    bombsCount++;
                }
            }

            if (col - 1 >= 0)
            {
                if (board[row, col - 1] == '*')
                {
                    bombsCount++;
                }
            }

            if (col + 1 < maxCol)
            {
                if (board[row, col + 1] == '*')
                {
                    bombsCount++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (board[row - 1, col - 1] == '*')
                {
                    bombsCount++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < maxCol))
            {
                if (board[row - 1, col + 1] == '*')
                {
                    bombsCount++;
                }
            }

            if ((row + 1 < maxRow) && (col - 1 >= 0))
            {
                if (board[row + 1, col - 1] == '*')
                {
                    bombsCount++;
                }
            }

            if ((row + 1 < maxRow) && (col + 1 < maxCol))
            {
                if (board[row + 1, col + 1] == '*')
                {
                    bombsCount++;
                }
            }

            return char.Parse(bombsCount.ToString());
        }

        public class Player
        {
            private string name;
            private int points;

            public Player()
            {
            }

            public Player(string name, int points)
            {
                this.name = name;
                this.points = points;
            }

            public string Name
            {
                get
                {
                    return this.name;
                }

                set
                {
                    this.name = value;
                }
            }

            public int Points
            {
                get
                {
                    return this.points;
                }

                set
                {
                    this.points = value;
                }
            }
        }
    }
}
