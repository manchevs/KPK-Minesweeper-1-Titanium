using System;
using System.Text;

namespace Mines
{
    public class MineField
    {
        private readonly int height;
        private readonly int width;
        private readonly int numberOfMines;

        private readonly char[,] display;
        private readonly bool[,] hasMine;
        private readonly bool[,] isShown;
        private readonly int[,] numberOfNeighbourMines;

        private bool shouldDisplayBoard;
        public int RevealedCellsCounter { get; set; }

        ////constructor
        public MineField(int width = 10, int height = 5, int numberOfMines = 15)
        {
            this.width = width;
            this.height = height;
            this.numberOfMines = numberOfMines;

            this.display = new char[height, width];
            this.hasMine = new bool[height, width];
            this.isShown = new bool[height, width];
            this.numberOfNeighbourMines = new int[height, width];

            this.ShouldDisplayBoard = true;
            this.InitializeBoardForDisplay();
            this.InitializeMines();
        }

        public bool ShouldDisplayBoard
        {
            get
            {
                return this.shouldDisplayBoard;
            }

            set
            {
                this.shouldDisplayBoard = value;
            }
        }
        
        private void InitializeMines()
        {
            Random generator = new Random();

            int placedMines = 0;
            while (placedMines < numberOfMines)
            {
                int x = generator.Next(height);
                int y = generator.Next(width);

                if (this.IsInsideTheField(x, y) && !this.hasMine[x, y])
                {
                    this.PlaceMine(x, y);
                    placedMines++;
                }
            }
        }

        private void PlaceMine(int x, int y)
        {
            this.hasMine[x, y] = true;
            this.ActualizeNeighbours(x, y);
        }

        public bool IsInsideTheField(int x, int y)
        {
            bool isInsideHorizontaly = 0 <= x && x < height;
            bool isInsideVerticaly = 0 <= y && y < width;
            return isInsideHorizontaly && isInsideVerticaly;
        }

        public bool IsAlreadyShown(int x, int y)
        {
            return this.isShown[x, y];
        }

        public bool IsMine(int x, int y)
        {
            return this.hasMine[x, y];
        }

        private void ActualizeNeighbours(int x, int y)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    bool isMainCell = (i == 0) && (j == 0);
                    if (!isMainCell && this.IsInsideTheField(x + i, y + j))
                    {
                        this.numberOfNeighbourMines[x + i, y + j]++;
                    }
                }
            }
        }

        private void InitializeBoardForDisplay()
        {
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    this.display[row, col] = '?';
                }
            }
        }

        public void RevealBlock(int x, int y)
        {
            this.display[x, y] = Convert.ToChar(this.numberOfNeighbourMines[x, y].ToString());
            this.RevealedCellsCounter++;
            this.isShown[x, y] = true;
            if (this.display[x, y] == '0')
            {
                for (int row = -1; row <= 1; row++)
                {
                    for (int col = -1; col <= 1; col++)
                    {
                        int newX = x + row;
                        int newY = y + col;
                        if (this.IsInsideTheField(newX, newY) && this.isShown[newX, newY] == false)
                        {
                            this.RevealBlock(newX, newY);
                        }
                    }
                }
            }
        }

        public void RevealAllMines()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (!this.isShown[i, j])
                    {
                        this.display[i, j] = '-';
                    }

                    if (this.hasMine[i, j])
                    {
                        this.display[i, j] = '*';
                    }
                }
            }
        }

        /// <summary>
        /// Method that returns the minesweeper mine field with all currently reviewed mines
        /// </summary>
        /// <example>
        /// This example shows how to use <see cref="ToString()"/> method.
        /// <code>
        ///     MineField mineField = new MineField();
        ///     Console.WriteLine(mineField.ToString());
        /// </code>
        /// </example>
        /// <returns>String containing the current state of the mine field</returns>
        public override string ToString()
        {
            StringBuilder mineField = new StringBuilder();
            mineField.Append(new string(' ', 4));
            for (int i = 0; i < width; i++)
            {
                mineField.Append(i);
                mineField.Append(' ');
            }

            mineField.Append(Environment.NewLine);
            mineField.Append(new string(' ', 4));
            mineField.Append(new string('-', 2 * width));
            mineField.Append(Environment.NewLine);
            for (int i = 0; i < height; i++)
            {
                mineField.Append(i);
                mineField.Append(" | ");
                for (int j = 0; j < width; j++)
                {
                    mineField.Append(this.display[i, j]);
                    mineField.Append(' ');
                }

                mineField.Append('|');
                mineField.Append(Environment.NewLine);
            }

            mineField.Append(new string(' ', 4));
            mineField.Append(new string('-', 2 * width));

            return mineField.ToString();
        }
    }
}