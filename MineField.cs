using System;
using System.Text;

namespace Mines
{
    public class MineField
    {
        private const int SizeX = 5;
        private const int SizeY = 10;
        private const int NumberOfMines = 15;

        private char[,] display;
        private bool[,] hasMine;
        private bool[,] isShown;
        private int[,] numberOfNeighbourMines;

        internal int RevealedCellsCounter { get; set; }

        public MineField()
        {
            this.display = new char[SizeX, SizeY];
            this.hasMine = new bool[SizeX, SizeY];
            this.isShown = new bool[SizeX, SizeY];
            this.numberOfNeighbourMines = new int[SizeX, SizeY];
            InitializeBoardForDisplay();
            InitializeMines();
        }

        private void InitializeMines()
        {
            Random generator = new Random();

            int placedMines = 0;
            while (placedMines < NumberOfMines)
            {
                if (PlaceMine(generator.Next(SizeX), generator.Next(SizeY)))
                {
                    placedMines++;
                }
            }
        }

        private bool PlaceMine(int x, int y)
        {
            if (IsInsideTheField(x, y) && !hasMine[x, y])
            {
                hasMine[x, y] = true;
                ActualizeNeighbours(x, y);

                return true;
            }

            return false;
        }

        public bool IsInsideTheField(int x, int y)
        {
            bool isInsideHorizontaly = 0 <= x && x < SizeX;
            bool isInsideVerticaly = 0 <= y && y < SizeY;
            return isInsideHorizontaly && isInsideVerticaly;
        }

        public bool IsAlreadyShown(int x, int y)
        {
            return isShown[x, y];
        }

        public bool IsMine(int x, int y)
        {
            return hasMine[x, y];
        }

        private void ActualizeNeighbours(int x, int y)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (((i != 0) || (j != 0)) && IsInsideTheField(x + i, y + j))
                    {
                        numberOfNeighbourMines[x + i, y + j]++;
                    }
                }
            }
        }

        private void InitializeBoardForDisplay()
        {
            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    display[i, j] = '?';
                }
            }
        }

        public void Initialize()
        {
            StringBuilder initialText = new StringBuilder();
            initialText.Append(new String(' ', 4));
            for (int i = 0; i < SizeY; i++)
            {
                initialText.Append(i);
                initialText.Append(' ');
            }

            initialText.Append(Environment.NewLine);
            initialText.Append(new String(' ', 4));
            initialText.Append(new String('-', 2 * SizeY));
            initialText.Append(Environment.NewLine);
            for (int i = 0; i < SizeX; i++)
            {
                initialText.Append(i);
                initialText.Append(" | ");
                for (int j = 0; j < SizeY; j++)
                {
                    initialText.Append(display[i, j]);
                    initialText.Append(' ');
                }

                initialText.Append('|');
                initialText.Append(Environment.NewLine);
            }

            initialText.Append(new String(' ', 4));
            initialText.Append(new String('-', 2 * SizeY));

            Console.WriteLine(initialText);
        }

        
        public void RevealBlock(int x, int y)
        {
            display[x, y] = Convert.ToChar(numberOfNeighbourMines[x, y].ToString());
            RevealedCellsCounter++;
            isShown[x, y] = true;
            if (display[x, y] == '0')
            {
                for (int xx = -1; xx <= 1; xx++)
                    for (int yy = -1; yy <= 1; yy++)
                    {
                        int newX = x + xx;
                        int newY = y + yy;
                        if (IsInsideTheField(newX, newY) && isShown[newX, newY] == false)
                            RevealBlock(newX, newY);
                    }
            }
        }

        public void DisplayAllMines(int x, int y)
        {
            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    if (!isShown[i, j])
                    {
                        display[i, j] = '-';
                    }
                    if (hasMine[i, j])
                    {
                        display[i, j] = '*';
                    }
                }
            }
        }
    }
}