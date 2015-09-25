namespace _06.ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class ConnectedAreasInMatrix
    {
        private static char[,] ma3xOne =
            {
                 { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' },                               
                 { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' },                               
                 { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' },                               
                 { ' ', ' ', ' ', ' ', '*', ' ', '*', ' ', ' ' },                               
            };

        private static char[,] ma3xTwo =
            {
                 { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' },                               
                 { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' },                               
                 { '*', ' ', ' ', '*', '*', '*', '*', '*', ' ', ' ' },                               
                 { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' },                               
                 { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' },                               
            };

        private static bool hasTopLeftCorner;

        private static List<Area> areasFound = new List<Area>();

        private static int stepsTaken;

        private static void Main()
        {
            int[] positions = FindTopLeftCorner(ma3xTwo);

            while (hasTopLeftCorner)
            {
                int cellRow = positions[0];
                int cellCol = positions[1];

                var area = new Area(cellRow, cellCol);
                FindAreas(cellRow, cellCol, ma3xTwo);
                area.Size = stepsTaken;
                stepsTaken = 0;
                areasFound.Add(area);

                positions = FindTopLeftCorner(ma3xTwo);
            }

            PrintAreas();
        }

        private static void FindAreas(int row, int col, char[,] matrix)
        {
            int numRows = matrix.GetLength(0);
            int numCols = matrix.GetLength(1);

            if (row < 0 || row >= numRows || col < 0 || col >= numCols)
            {
                return;
            }

            if (matrix[row, col] != ' ')
            {
                return;
            }

            matrix[row, col] = 'x';
            stepsTaken++;

            FindAreas(row, col + 1, matrix);
            FindAreas(row, col - 1, matrix);
            FindAreas(row + 1, col, matrix);
            FindAreas(row - 1, col, matrix);
        }

        private static int[] FindTopLeftCorner(char[,] matrix)
        {
            int[] positions = new int[2];
            hasTopLeftCorner = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char current = matrix[row, col];

                    if (current == ' ')
                    {
                        positions[0] = row;
                        positions[1] = col;
                        hasTopLeftCorner = true;
                        return positions;
                    }
                }
            }

            return positions;
        }

        private static void PrintAreas()
        {
            var orderedAreas = areasFound.OrderByDescending(a => a.Size).ThenBy(a => a.X).ThenBy(a => a.Y);
            Console.WriteLine("Total areas found: " + orderedAreas.Count());
            int areaNumber = 1;
            foreach (Area area in orderedAreas)
            {
                Console.WriteLine("Area #{0} at ({1}, {2}), size: {3}", areaNumber, area.X, area.Y, area.Size);
                areaNumber++;
            }
        }
    }
}