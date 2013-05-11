using System;

namespace Mines
{
    public class MinesweeperGame
    {
        public static void Main()
        {
            Board scoreBoard = new Board();
            MineField board = new MineField();
            Console.WriteLine("Welcome to the game “Minesweeper”. Try to reveal all cells without mines. Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            Console.WriteLine();

            while (true)
            {
                if (board.ShouldDisplayBoard)
                {
                    Console.WriteLine(board.ToString());
                }
                
                board.ShouldDisplayBoard = true;
                Console.Write("Enter row and column: ");

                ExecuteCommand(board, scoreBoard);
            }
        }

        private static void ExecuteCommand(MineField board, Board scoreBoard)
        {
            Commands.ReadCommand();

            if (Commands.ValidCommand)
            {
                ExecuteSpecialCommand(board, scoreBoard);

                ExecuteRevealBlockCommand(board, scoreBoard);
            }
            else
            {
                Console.WriteLine("Illegal command!");
                board.ShouldDisplayBoard = false;
            }
        }
  
        private static void ExecuteRevealBlockCommand(MineField board, Board scoreBoard)
        {
            int x = Commands.X;
            int y = Commands.Y;

            if (!board.IsInsideTheField(x, y) || board.IsAlreadyShown(x, y))
            {
                Console.WriteLine("Illegal move!");
                Console.WriteLine();
                board.ShouldDisplayBoard = false;
            }
            else
            {
                if (board.IsMine(x, y))
                {
                    board.RevealAllMines();
                    Console.WriteLine(board.ToString());
                    Console.WriteLine("Booooom! You were killed by a mine. You revealed {0} cells without mines.", board.RevealedCellsCounter);
                    Console.WriteLine();
                    if (scoreBoard.Count() < 5 || board.RevealedCellsCounter > scoreBoard.MinInTop5())
                    {
                        scoreBoard.AddScore(board.RevealedCellsCounter);
                    }

                    scoreBoard.ShowScore();
                    Main();
                }
                else
                {
                    board.RevealBlock(x, y);
                }
            }
        }
  
        private static void ExecuteSpecialCommand(MineField board, Board scoreBoard)
        {
            if (Commands.GetStatistic)
            {
                scoreBoard.ShowScore();
                board.ShouldDisplayBoard = false;
                Commands.CommandsInitialization();
            }
            else if (Commands.Exit)
            {
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
            }
            else if (Commands.Restart)
            {
                Main();
            }
        }
    }
}
