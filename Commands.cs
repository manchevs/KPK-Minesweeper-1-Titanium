using System;

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
        internal static bool Flag;

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

        public static bool IsSpecialCommand()
        {
            if (Exit || GetStatistic || Restart || Flag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void NextMove(string command)
        {
            string[] nextPoint = command.Split(' ');

            if (nextPoint.Length < 2 || nextPoint.Length > 3)
            {
                ValidCommand = false;
            }
            else if (nextPoint[0] == "flag")
            {
                ParseCoordinates(nextPoint[1], nextPoint[2]);
                Flag = true;
            }
            else
            {
                ParseCoordinates(nextPoint[0], nextPoint[1]);
            }
        }

        private static void ParseCoordinates(string firstCoord, string secondCoord)
        {
            try
            {
                X = Convert.ToInt32(firstCoord);
                Y = Convert.ToInt32(secondCoord);
            }
            catch (FormatException)
            {
                ValidCommand = false;
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
            Flag = false;
        }
    }
}
