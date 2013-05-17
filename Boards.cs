using System;

namespace Mines
{
    /// <summary>
    /// Class for keeping information of each MineField Cell with the status
    /// (is visibla, has mine, neighbours with mine, is shown.)
    /// </summary>
    public class Boards
    {
        private readonly char[,] visible;
        private readonly bool[,] hasMine;
        private readonly bool[,] isShown;
        private readonly int[,] numberOfNeighbourMines;

        public Boards(int height, int width)
        {
            if (height <= 0 || width <= 0)
            {
                throw new ArgumentException("Height and Width must be possitive numbers!");
            }

            this.visible = new char[height, width];
            this.hasMine = new bool[height, width];
            this.isShown = new bool[height, width];
            this.numberOfNeighbourMines = new int[height, width];
        }

        /// <summary>
        /// Gets the matrix that holds the visual state of the game field
        /// </summary>
        public char[,] Visible
        {
            get
            {
                return this.visible;
            }
        }

        /// <summary>
        /// Gets the matrix that holds the mines on the game field
        /// </summary>
        public bool[,] HasMine
        {
            get
            {
                return this.hasMine;
            }
        }

        /// <summary>
        /// Gets the matrix that holds the information about the visibility state of the game field
        /// </summary>
        public bool[,] IsShown
        {
            get
            {
                return this.isShown;
            }
        }

        /// <summary>
        /// Gets the matrix that holds the information about the number of neighbour mines of each cell
        /// </summary>
        public int[,] NumberOfNeighbourMines
        {
            get
            {
                return this.numberOfNeighbourMines;
            }
        }
    }
}
