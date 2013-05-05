using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mines
{
    internal static class Commands
    {
        internal static int X { get; set; }
        internal static int Y { get; set; }
        internal static bool Exit;
        internal static bool GetStatistic;
        internal static bool ValidCommand;
        internal static bool Restart;

        internal static void ReadCommand()
        {
            CommandsInitialization();

            string command = Console.ReadLine();
            command = command.Trim();
            command = command.ToLower();

            switch (command)
            {
                case "exit":
                    Exit = true;
                    return;
                case "top":
                    GetStatistic = true;
                    return;
                case "restart":
                    Restart = true;
                    return;
                default:
                    NextMove(command);
                    break;
            }
        }

        private static void NextMove(string command)
        {
            string[] nextPoint = command.Split(' ');

            if (nextPoint.Length != 2)
            {
                ValidCommand = false;
            }
            else
            {
                try
                {
                    X = Convert.ToInt32(nextPoint[0]);
                    Y = Convert.ToInt32(nextPoint[1]);
                }
                catch (FormatException)
                {
                    ValidCommand = false;
                }
            }
        }

        internal static void CommandsInitialization()
        {
            X = 0;
            Y = 0;
            Exit = false;
            GetStatistic = false;
            ValidCommand = true;
            Restart = false;
        }
    }
}
