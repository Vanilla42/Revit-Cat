using System;
using System.ComponentModel;

namespace Revit_Cat
{
    public class GameModel
    {
        private const int CELLS_COUNT_COLUMNS = 10;
        private const int CELLS_COUNT_ROWS = 10;
        private const double MOUSE_PERCENTAGE = 0.10;

        /// <summary>
        /// Array with bools if cell has mouse inside of it.
        /// </summary>
        public bool[,] IsMouse { get; private set; }
        /// <summary>
        /// Array with numbers how many mouses are adjacent to this cell.
        /// </summary>
        public int[,] NeighbourCounts { get; private set; }
        /// <summary>
        /// Array with bools if cell have been opened.
        /// </summary>
        public bool [,] IsOpened { get; set; }
        /// <summary>
        /// State flag that shows if game is running.
        /// </summary>
        public bool IsAlive { get; private set; }

        public GameModel()
        {
            IsAlive = true;
            IsMouse = GetArray(CELLS_COUNT_COLUMNS, CELLS_COUNT_ROWS, MOUSE_PERCENTAGE);
            NeighbourCounts = GetNeighbourCounts(IsMouse);
        }

        private bool[,] GetArray(int countColumns, int countRows, double percentageTrue)
        {
            bool[,] array = new bool[countColumns, countRows];

            Random random = new Random();
            for (int i = 0; i < countColumns; i++)
                for (int j = 0; j < countRows; j++)
                    if (random.NextDouble() < percentageTrue)
                        array[i, j] = true;

            return array;
        }

        private int[,] GetNeighbourCounts(bool[,] array)
        {
            int[,] neighbourCounts = new int[array.GetLength(0), array.GetLength(1)];

            // Go through array and if mouse in the cell add +1 to adjacent cells (if exists)
            for (int i = 0; i < CELLS_COUNT_COLUMNS; i++)
                for (int j = 0; j < CELLS_COUNT_ROWS; j++)
                {
                    if (array[i, j])
                    {
                        if (i > 0)
                        {
                            if (j > 0)
                                neighbourCounts[i - 1, j - 1]++;
                            neighbourCounts[i - 1, j]++;
                            if (j < CELLS_COUNT_ROWS - 1)
                                neighbourCounts[i - 1, j + 1]++;
                        }

                        if (j > 0)
                            neighbourCounts[i, j - 1]++;
                        if (j < CELLS_COUNT_ROWS - 1)
                            neighbourCounts[i, j + 1]++;

                        if (i < CELLS_COUNT_COLUMNS - 1)
                        {
                            neighbourCounts[i + 1, j - 1]++;
                            neighbourCounts[i + 1, j]++;
                            neighbourCounts[i + 1, j + 1]++;
                        }
                    }
                }

            return neighbourCounts;
        }

        private void OpenCell(int indexColumn, int indexRow)
        {
            if (IsOpened[indexColumn, indexRow])
                return;

            if (IsMouse[indexColumn, indexRow])
            {
                IsOpened[indexColumn, indexRow] = true;
                IsAlive = false;
            }

            IsOpened[indexColumn, indexRow] = true;

            if (NeighbourCounts[indexColumn, indexRow] == 0)
                OpenField(indexColumn, indexRow);
        }

        /// <summary>
        /// Open adjacent cells
        /// </summary>
        private void OpenField(int indexColumn, int indexRow)
        {
            if (indexColumn > 0)
            {
                if (indexRow > 0)
                    OpenCell(indexColumn - 1, indexRow - 1);
                OpenCell(indexColumn - 1, indexRow);
                if (indexRow < CELLS_COUNT_ROWS - 1)
                    OpenCell(indexColumn - 1, indexRow + 1);
            }

            if (indexRow > 0)
                OpenCell(indexColumn, indexRow - 1);
            if (indexRow < CELLS_COUNT_ROWS - 1)
                OpenCell(indexColumn, indexRow + 1);

            if (indexColumn < CELLS_COUNT_COLUMNS - 1)
            {
                if (indexRow > 0)
                    OpenCell(indexColumn + 1, indexRow - 1);
                OpenCell(indexColumn + 1, indexRow);
                if (indexRow < CELLS_COUNT_ROWS - 1)
                    OpenCell(indexColumn + 1, indexRow + 1);
            }
        }
    }
}
