using System;

namespace Mines
{
    public class CommandParser
    {
        private Cell currentCell;
        private string command;

        public string Command 
        {
            get
            {
                return this.command;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Command is not valid!");
                }

                this.command = value;
            }
        }

        public Cell CurrentCell
        {
            get
            {
                return this.currentCell;
            }

            private set 
            {
                this.currentCell = value;
            }
        }

        public bool TryReadCommand()
        {
            string command = Console.ReadLine();
            command = command.Trim();
            command = command.ToLower();

            try
            {
                if (command.StartsWith("flag") || Char.IsDigit(command[0]))
                {
                    NextMove(command);
                }
                else
                {
                    this.Command = command;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsSpecialCommand()
        {
            if (Char.IsLetter(this.Command[0]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void NextMove(string command)
        {
            string[] nextPoint = command.Split(' ');

            if (nextPoint[0] == "flag")
            {
                ParseCoordinates(nextPoint[1], nextPoint[2]);
                this.Command = nextPoint[0];
            }
            else
            {
                ParseCoordinates(nextPoint[0], nextPoint[1]);
                this.Command = string.Format("{0} {1}",nextPoint[0], nextPoint[1]);
            }
        }

        private void ParseCoordinates(string firstCoord, string secondCoord)
        {
            currentCell.Row = int.Parse(firstCoord);
            currentCell.Col = int.Parse(secondCoord);
        }
    }
}
