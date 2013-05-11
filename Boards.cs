using System;

namespace Mines
{
    public class Boards
    {
        private readonly char[,] visible;
        private readonly bool[,] hasMine;
        private readonly bool[,] isShown;
        private readonly int[,] numberOfNeighbourMines;

        public Boards(int height, int width)
        {
            if (height < 0 || width < 0)
            {
                throw new ArgumentException("Height and Width must be possitive numbers!");
            }

            this.visible = new char[height, width];
            this.hasMine = new bool[height, width];
            this.isShown = new bool[height, width];
            this.numberOfNeighbourMines = new int[height, width];
        }

        public char[,] Visible
        {
            get
            {
                return this.visible;
            }
        }

        public bool[,] HasMine
        {
            get
            {
                return this.hasMine;
            }
        }

        public bool[,] IsShown
        {
            get
            {
                return this.isShown;
            }
        }

        public int[,] NumberOfNeighbourMines
        {
            get
            {
                return this.numberOfNeighbourMines;
            }
        }
    }
}
