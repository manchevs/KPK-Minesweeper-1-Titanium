using System;

namespace Mines
{
    /// <summary>
    /// Check the command type and parse the next move coordinates
    /// </summary>
    public class CommandParser
    {
        private Cell currentCell;
        private string command;

        /// <summary>
        /// Keeps the commant name
        /// </summary>
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

        /// <summary>
        /// Keeps the current cell coordinats
        /// </summary>
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

        /// <summary>
        /// Check if it is a regular command
        /// </summary>
        /// <param name="command">Command name read</param>
        /// <returns>True if regular command</returns>
        public bool TryParseCommand(string command)
        {
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

        /// <summary>
        /// Check if it is a special command for top scores, end game, etc.
        /// </summary>
        /// <returns>True if special command</returns>
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

        /// <summary>
        /// Parse coordinats for the next move
        /// </summary>
        /// <param name="command">Command name read</param>
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

        /// <summary>
        /// Convert coordinates from striing to int
        /// </summary>
        /// <param name="firstCoord">Row</param>
        /// <param name="secondCoord">Column</param>
        private void ParseCoordinates(string firstCoord, string secondCoord)
        {
            currentCell.Row = int.Parse(firstCoord);
            currentCell.Col = int.Parse(secondCoord);
        }
    }
}
