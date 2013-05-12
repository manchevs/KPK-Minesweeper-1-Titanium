using System;

namespace Mines
{
    public class MinesweeperGame
    {
        private static readonly Board scoreBoard = new Board();

        public static void Main()
        {
            MineField mineField = new MineField();
            GameMessages.StartGame();

            while (true)
            {
                if (mineField.ShouldDisplayBoard)
                {
                    GameMessages.DrawGameField(mineField.ToString());
                }

                mineField.ShouldDisplayBoard = true;
                GameMessages.Entry();

                ExecuteCommand(mineField, scoreBoard);
            }
        }

        private static void ExecuteCommand(MineField mineField, Board scoreBoard)
        {
            Commands.ReadCommand();

            if (Commands.ValidCommand)
            {
                if (Commands.IsSpecialCommand())
                {
                    ExecuteSpecialCommand(mineField, scoreBoard);
                }
                else
                {
                    ExecuteRevealBlockCommand(mineField, scoreBoard);
                }
            }
            else
            {
                GameMessages.IlligalCommand();
                mineField.ShouldDisplayBoard = false;
            }
        }

        private static void ExecuteRevealBlockCommand(MineField mineField, Board scoreBoard)
        {
            int x = Commands.X;
            int y = Commands.Y;

            if (mineField.IsInsideTheField(x, y) && !mineField.IsAlreadyShown(x, y))
            {
                if (mineField.IsMine(x, y))
                {
                    mineField.RevealAllMines();
                    GameMessages.DrawGameField(mineField.ToString());
                    GameMessages.EndGame(mineField.RevealedCellsCounter);
                    if (scoreBoard.Count() < 5 || mineField.RevealedCellsCounter > scoreBoard.MinInTop5())
                    {
                        scoreBoard.AddScore(mineField.RevealedCellsCounter);
                    }

                    scoreBoard.ShowScore();
                    Main();
                }
                else
                {
                    mineField.RevealBlock(x, y);
                }
            }
            else
            {
                GameMessages.IlligalMove();
                mineField.ShouldDisplayBoard = false;
            }
        }

        private static void ExecuteSpecialCommand(MineField mineField, Board scoreBoard)
        {
            if (Commands.GetStatistic)
            {
                scoreBoard.ShowScore();
                mineField.ShouldDisplayBoard = false;
                Commands.CommandsInitialization();
            }
            else if (Commands.Exit)
            {
                GameMessages.Exit();
                Environment.Exit(0);
            }
            else if (Commands.Restart)
            {
                Main();
            }
            else if (Commands.Flag)
            {
                ExecuteFlagCommand(mineField);
            }
        }

        private static void ExecuteFlagCommand(MineField mineField)
        {
            int x = Commands.X;
            int y = Commands.Y;

            if (mineField.IsInsideTheField(x, y) && !mineField.IsAlreadyShown(x, y))
            {
                mineField.AddRemoveFlag(x, y);
            }
            else
            {
                GameMessages.IlligalMove();
                mineField.ShouldDisplayBoard = false;
            }
        }

    }
}
