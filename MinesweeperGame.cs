using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace Mines
{

    // Аз съм българче и пиша на БЪЛГАРСКИ!

    class MinesweeperGame
    {
        static void Main()
        {

            Board scoreboard = new Board();
        ДайНаново:
            bool displayBoard = true;
            MineField board = new MineField();
            Console.WriteLine("Welcome to the game “Minesweeper”. Try to reveal all cells without mines. Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            Console.WriteLine();

            while (true)
            {
                if (displayBoard)
                    board.Initialize();
                displayBoard = true;
                Console.Write("Enter row and column: ");
                Commands.ReadCommand();

                if (Commands.ValidCommand)
                {
                    if (Commands.GetStatistic)
                    {
                        scoreboard.ShowScore();
                        displayBoard = false;
                        Commands.CommandsInitialization();
                        continue;
                    }
                    if (Commands.Exit)
                    {
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                    }
                    if (Commands.Restart)
                    {//ako iskahs pak skakash neznaino kyde
                        // ama pyk si bachka
                        goto ДайНаново;
                    }

                    int x = Commands.X;
                    int y = Commands.Y;
                    if (!board.IsInsideTheField(x, y) || board.IsAlreadyShown(x, y))
                    {
                        Console.WriteLine("Illegal move!");
                        Console.WriteLine();
                        displayBoard = false;
                    }
                    else
                    {
                        if (board.IsMine(x, y))
                        {
                            board.DisplayAllMines(x, y);
                            board.Initialize();
                            Console.WriteLine("Booooom! You were killed by a mine. You revealed " + board.RevealedCellsCounter + " cells without mines.");
                            Console.WriteLine();
                            if (board.RevealedCellsCounter > scoreboard.MinInTop5() || scoreboard.Count() < 5)
                            {
                                scoreboard.AddScore(board.RevealedCellsCounter);
                            }
                            scoreboard.ShowScore();
                            goto ДайНаново;
                        }
                        else
                            board.RevealBlock(x, y);
                    }
                }
                else
                {
                    Console.WriteLine("Illegal command!");
                    displayBoard = false;
                }
            }
        }
    }
}
