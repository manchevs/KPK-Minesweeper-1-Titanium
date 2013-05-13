using System;
using System.Text;

namespace Mines
{
    /// <summary>
    /// Class that represents a mine field. It tracks the current state of the cells
    /// onto the board and actualize all changes made to the field.
    /// </summary>
    public class MineField
    {
        /// <summary>
        /// The height of the mine field.
        /// </summary>
        private readonly int height;

        /// <summary>
        /// The width of the mine field.
        /// </summary>
        private readonly int width;

        /// <summary>
        /// The number of the mines placed on the field.
        /// </summary>
        private readonly int numberOfMines;

        /// <summary>
        /// The arrays with track the changes onto the mine field.
        /// </summary>
        private readonly Boards boards;

        /// <summary>
        /// The count of the revealed cells onto the mine field.
        /// </summary>
        private int revealedCellsCounter;

        private int expectedMinesLeft;

        /// <summary>
        /// Initializes a new instance of the <see cref="MineField"/> class
        /// which represents minesweeper game field.
        /// </summary>
        /// <param name="width">The width of the game field</param>
        /// <param name="height">The height of the game field</param>
        /// <param name="numberOfMines">The number of the mines that should be put on the field</param>
        public MineField(int width = 10, int height = 5, int numberOfMines = 15)
        {
            if (height < 0 || width < 0)
            {
                throw new ArgumentException("Height and Width must be possitive numbers!");
            }

            if (numberOfMines > width * height)
            {
                throw new ArgumentException("Number of mines could not be larger than the number of cells on the field!");
            }

            this.width = width;
            this.height = height;
            this.numberOfMines = numberOfMines;
            this.boards = new Boards(height, width);
            this.expectedMinesLeft = numberOfMines;

            this.InitializeBoardForDisplay();
            this.InitializeMines();
        }

        /// <summary>
        /// Gets the number of revealed cells on the game field.
        /// </summary>
        public int RevealedCellsCounter
        {
            get
            {
                return this.revealedCellsCounter;
            }

            private set
            {
                this.revealedCellsCounter = value;
            }
        }

        /// <summary>
        /// Method that checks if the cell on the corresponding coordinates
        /// is inside the game field. Uses <see cref="width"/> and <see cref="height"/>
        /// to define the game field dimensions.
        /// </summary>
        /// <param name="x">The X coordinate of the cell</param>
        /// <param name="y">The Y coordinate of the cell</param>
        /// <returns>Returns true if the corresponding cell is inside the game field</returns>
        public bool IsInsideTheField(int x, int y)
        {
            bool isInsideHorizontaly = 0 <= x && x < this.height;
            bool isInsideVerticaly = 0 <= y && y < this.width;
            return isInsideHorizontaly && isInsideVerticaly;
        }

        /// <summary>
        /// Method that checks if the cell on the corresponding coordinates
        /// is already visible. Uses <see cref="Boards.IsShown"/> array to track the results.
        /// </summary>
        /// <param name="x">The X coordinate of the cell</param>
        /// <param name="y">The Y coordinate of the cell</param>
        /// <returns>Returns true if the corresponding cell is already shown</returns>
        public bool IsAlreadyShown(int x, int y)
        {
            return this.boards.IsShown[x, y];
        }

        /// <summary>
        /// Method that checks if the cell on the corresponding coordinates
        /// is a mine field. Uses <see cref="Boards.HasMine"/> array to track the results.
        /// </summary>
        /// <param name="x">The X coordinate of the cell</param>
        /// <param name="y">The Y coordinate of the cell</param>
        /// <returns>Returns true if the corresponding cell is a mine field</returns>
        public bool IsMine(int x, int y)
        {
            return this.boards.HasMine[x, y];
        }

        /// <summary>
        /// Method that generate random X and Y coordinates and places a mine on the
        /// corresponding cell using <see cref="PlaceMine"/> method.
        /// </summary>
        private void InitializeMines()
        {
            Random generator = new Random();

            int placedMines = 0;
            while (placedMines < this.numberOfMines)
            {
                int x = generator.Next(this.height);
                int y = generator.Next(this.width);

                if (this.IsInsideTheField(x, y) && !this.boards.HasMine[x, y])
                {
                    this.PlaceMine(x, y);
                    placedMines++;
                }
            }
        }

        /// <summary>
        /// Method that places a mine into a cell using <see cref="Boards.HasMine"/> array
        /// to mark the results.
        /// Actualizing the numbers of all neighbour cells with <see cref="ActualizeNeighbourMinesNumber"/>
        /// </summary>
        /// <param name="x">The X coordinate of the cell</param>
        /// <param name="y">The Y coordinate of the cell</param>
        private void PlaceMine(int x, int y)
        {
            this.boards.HasMine[x, y] = true;
            this.ActualizeNeighbourMinesNumber(x, y);
        }

        /// <summary>
        /// Method that counts the number of neighbour mines number.
        /// The result is written in <see cref="Boards.NumberOfNeighbourMines"/> Array.
        /// </summary>
        /// <param name="x">The X coordinate of the cell</param>
        /// <param name="y">The Y coordinate of the cell</param>
        private void ActualizeNeighbourMinesNumber(int x, int y)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    bool isMainCell = (i == 0) && (j == 0);
                    if (!isMainCell && this.IsInsideTheField(x + i, y + j))
                    {
                        this.boards.NumberOfNeighbourMines[x + i, y + j]++;
                    }
                }
            }
        }

        /// <summary>
        /// Replaces all cell's chars in <see cref="Boards.Visible"/> array with '?' symbol 
        /// </summary>
        private void InitializeBoardForDisplay()
        {
            for (int row = 0; row < this.height; row++)
            {
                for (int col = 0; col < this.width; col++)
                {
                    this.boards.Visible[row, col] = '?';
                }
            }
        }

        /// <summary>
        /// Method that reveals a cell on the game field by replacing it's char with a number
        /// corresponding to the mines in it's neighbour cells.
        /// If the number of the neighbour mines is 0 the method calls itself recursivly and
        /// reveals all neighbour cells.
        /// </summary>
        /// <param name="x">The X coordinate of the cell</param>
        /// <param name="y">The Y coordinate of the cell</param>
        public void RevealBlock(int x, int y)
        {
            char neighbourCells = Convert.ToChar(this.boards.NumberOfNeighbourMines[x, y].ToString());
            if (neighbourCells == '0')
            {
                this.boards.Visible[x, y] = ' ';
            }
            else
            {
                this.boards.Visible[x, y] = neighbourCells;
            }

            this.RevealedCellsCounter++;
            this.boards.IsShown[x, y] = true;
            if (this.boards.Visible[x, y] == ' ')
            {
                for (int row = -1; row <= 1; row++)
                {
                    for (int col = -1; col <= 1; col++)
                    {
                        int newX = x + row;
                        int newY = y + col;
                        if (this.IsInsideTheField(newX, newY) && this.boards.IsShown[newX, newY] == false)
                        {
                            this.RevealBlock(newX, newY);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method that adds or removes a flag from a cell.
        /// </summary>
        /// <param name="x">The X coordinate of the cell</param>
        /// <param name="y">The Y coordinate of the cell</param>
        public void AddRemoveFlag(int x, int y)
        {
            if (this.boards.Visible[x, y] == '?')
            {
                this.boards.Visible[x, y] = '!';
                this.expectedMinesLeft--;
            }
            else
            {
                this.boards.Visible[x, y] = '?';
                this.expectedMinesLeft++;
            }
        }

        /// <summary>
        /// Method that reveal all mines on the game field after the game has ended.
        /// Replaces all unrevealed cells with '-' and visualize the mines as '*'
        /// </summary>
        public void RevealAllMines()
        {
            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    if (!this.boards.IsShown[i, j])
                    {
                        this.boards.Visible[i, j] = '-';
                    }

                    if (this.boards.HasMine[i, j])
                    {
                        this.boards.Visible[i, j] = '*';
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
            for (int i = 0; i < this.width; i++)
            {
                mineField.Append(i);
                mineField.Append(' ');
            }

            mineField.Append(Environment.NewLine);
            mineField.Append(new string(' ', 4));
            mineField.Append(new string('-', 2 * this.width));
            mineField.Append(Environment.NewLine);
            for (int row = 0; row < this.height; row++)
            {
                mineField.Append(row);
                mineField.Append(" | ");
                for (int col = 0; col < this.width; col++)
                {
                    mineField.Append(this.boards.Visible[row, col]);
                    mineField.Append(' ');
                }

                mineField.Append('|');
                mineField.Append(Environment.NewLine);
            }

            mineField.Append(new string(' ', 4));
            mineField.Append(new string('-', 2 * this.width));
            mineField.Append(new string(' ', 4));
            mineField.Append("Mines left: ");
            mineField.Append(this.expectedMinesLeft);

            return mineField.ToString();
        }
    }
}