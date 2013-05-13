using System;

namespace Mines
{
    /// <summary>
    /// Static class containing game messages that are visualized 
    /// on the <see cref="System.Console"/> during the game process.
    /// </summary>
    public static class GameMessages
    {
        public static void StartGame()
        {
            Console.WriteLine("Welcome to the game “Minesweeper”. Try to reveal all cells without mines.");
            Console.WriteLine("To reveal cells enter row and column of the cell with space for separator -     \"0 0\"");
            Console.WriteLine("Use 'flag' command to flag/unflag cells - \"flag 0 0\"");
            Console.WriteLine("Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            Console.WriteLine();
        }

        public static void IlligalCommand()
        {
            Console.WriteLine("Illegal command!");
        }

        public static void IlligalMove()
        {
            Console.WriteLine("Illegal move!");
            Console.WriteLine();
        }

        public static void Entry()
        {
            Console.Write("Enter row and column: ");
        }

        public static void EndGame(int revealedCells)
        {
            Console.WriteLine("\n\nGAME OVER\n\n");
            Console.WriteLine("Booooom! You were killed by a mine. You revealed {0} cells without mines.", revealedCells);
            Console.WriteLine();
        }

        public static void Exit()
        {
            Console.WriteLine("Goodbye!");
        }

        public static void DrawGameField(string gameField)
        {
            Console.WriteLine(gameField);
        }
    }
}
