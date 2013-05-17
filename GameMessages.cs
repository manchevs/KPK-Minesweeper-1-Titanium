using System;

namespace Mines
{
    /// <summary>
    /// Static class containing game messages that are visualized 
    /// on the <see cref="System.Console"/> during the game process.
    /// </summary>
    public static class GameMessages
    {
        /// <summary>
        /// Method that prints the welcome message of the game
        /// </summary>
        public static void StartGame()
        {
            Console.WriteLine("Welcome to the game “Minesweeper”. Try to reveal all cells without mines.");
            Console.WriteLine("To reveal cells enter row and column of the cell with space for separator -     \"0 0\"");
            Console.WriteLine("Use 'flag' command to flag/unflag cells - \"flag 0 0\"");
            Console.WriteLine("Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            Console.WriteLine();
        }

        /// <summary>
        /// Method that prints on <see cref="System.Console"/> the Illigal command message
        /// </summary>
        public static void IlligalCommand()
        {
            Console.WriteLine("Illegal command!");
        }

        /// <summary>
        /// Method that prints on <see cref="System.Console"/> the Illigal move message
        /// </summary>
        public static void IlligalMove()
        {
            Console.WriteLine("Illegal move!");
            Console.WriteLine();
        }

        /// <summary>
        /// Method that prints on <see cref="System.Console"/> 
        /// the entry message
        /// </summary>
        public static void Entry()
        {
            Console.Write("Enter row and column: ");
        }

        /// <summary>
        /// Method that prints on <see cref="System.Console"/> 
        /// the message after the game is over with the correct amount of mines
        /// openned during the game.
        /// </summary>
        /// <param name="revealedCells">The number of mines the player has opened during the game</param>
        public static void EndGame(int revealedCells)
        {
            Console.WriteLine("\n\nGAME OVER\n\n");
            Console.WriteLine("Booooom! You were killed by a mine. You revealed {0} cells without mines.", revealedCells);
            Console.WriteLine();
        }

        /// <summary>
        /// Method that prints on <see cref="System.Console"/> the message
        /// which apear after the exit command is executed
        /// </summary>
        public static void Exit()
        {
            Console.WriteLine("Goodbye!");
        }

        /// <summary>
        /// Method that prints on <see cref="System.Console"/> the visual state of the gamefield
        /// </summary>
        /// <param name="gameField"></param>
        public static void DrawGameField(string gameField)
        {
            Console.WriteLine(gameField);
        }
    }
}
