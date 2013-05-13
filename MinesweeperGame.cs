﻿using System;

namespace Mines
{
    public class MinesweeperGame
    {
        private static readonly Board scoreBoard = new Board();
        private static bool shouldDisplayBoard = true;

        public static void Main()
        {
            MineField mineField = new MineField();
            

            while (true)
            {
                if (shouldDisplayBoard)
                {
                    Console.Clear();
                    GameMessages.StartGame();
                    GameMessages.DrawGameField(mineField.ToString());
                }

                shouldDisplayBoard = true;
                GameMessages.Entry();

                ExecuteCommand(mineField);
            }
        }

        private static void ExecuteCommand(MineField mineField)
        {
            CommandParser commandParser = new CommandParser();
            bool parsedCommand = commandParser.TryReadCommand();

            if (parsedCommand)
            {
                if (commandParser.IsSpecialCommand())
                {
                    ExecuteSpecialCommand(mineField, commandParser);
                }
                else
                {
                    ExecuteRevealBlockCommand(mineField, commandParser.CurrentCell);
                }
            }
            else
            {
                GameMessages.IlligalCommand();
                shouldDisplayBoard = false;
            }
        }

        private static void ExecuteRevealBlockCommand(MineField mineField, Cell currentCell)
        {
            int row = currentCell.Row;
            int col = currentCell.Col;

            if (mineField.IsInsideTheField(row, col) && !mineField.IsAlreadyShown(row, col))
            {
                if (mineField.IsMine(row, col))
                {
                    mineField.RevealAllMines();
                    Console.Clear();
                    GameMessages.EndGame(mineField.RevealedCellsCounter);
                    GameMessages.DrawGameField(mineField.ToString());
                    if (scoreBoard.Count() < 5 || mineField.RevealedCellsCounter > scoreBoard.MinInTop5())
                    {
                        scoreBoard.AddScore(mineField.RevealedCellsCounter);
                    }

                    scoreBoard.ShowScore();
                    Main();
                }
                else
                {
                    mineField.RevealBlock(row, col);
                }
            }
            else
            {
                GameMessages.IlligalMove();
                shouldDisplayBoard = false;
            }
        }

        private static void ExecuteSpecialCommand(MineField mineField, CommandParser commandParser)
        {
            if (commandParser.Command == "top")
            {
                scoreBoard.ShowScore();
                shouldDisplayBoard = false;
            }
            else if (commandParser.Command == "exit")
            {
                GameMessages.Exit();
                Environment.Exit(0);
            }
            else if (commandParser.Command == "restart")
            {
                Main();
            }
            else if (commandParser.Command == "flag")
            {
                ExecuteFlagCommand(mineField, commandParser.CurrentCell);
            }
            else
            {
                GameMessages.IlligalCommand();
                shouldDisplayBoard = false;
            }
        }

        private static void ExecuteFlagCommand(MineField mineField, Cell currentCell)
        {
            int row = currentCell.Row;
            int col = currentCell.Col;

            if (mineField.IsInsideTheField(row, col) && !mineField.IsAlreadyShown(row, col))
            {
                mineField.AddRemoveFlag(row, col);
            }
            else
            {
                GameMessages.IlligalMove();
                shouldDisplayBoard = false;
            }
        }

    }
}
