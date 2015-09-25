namespace _05.PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;

    internal class PathsBetweenCellsInMatrix
    {
        private static char[,] ma3XOne =
            {
                { 's', ' ', ' ', ' ' }, 
                { ' ', '*', '*', ' ' }, 
                { ' ', '*', '*', ' ' },
                { ' ', '*', 'e', ' ' }, 
                { ' ', ' ', ' ', ' ' }
            };

        private static char[,] ma3XTwo =
            {
                { 's', ' ', ' ', ' ', ' ', ' ' }, 
                { ' ', '*', '*', ' ', '*', ' ' }, 
                { ' ', '*', '*', ' ', '*', ' ' },
                { ' ', '*', 'e', ' ', ' ', ' ' }, 
                { ' ', ' ', ' ', '*', ' ', ' ' }
            };

        private static List<char> path = new List<char>();

        private static int totalPaths;

        private static void Main()
        {
            FindExit(0, 0, ma3XTwo, 'S');
            Console.WriteLine("Total paths found: {0}", totalPaths);
        }

        private static void FindExit(int row, int col, char[,] matrix, char direction)
        {
            int numRows = matrix.GetLength(0);
            int numCols = matrix.GetLength(1);

            if (row < 0 || row >= numRows || col < 0 || col >= numCols)
            {
                return;
            }

            if (matrix[row, col] == 'e')
            {
                totalPaths++;
                Console.WriteLine(string.Join(string.Empty, path) + direction);
                return;
            }

            if (matrix[row, col] != ' ' && matrix[row, col] != 's')
            {
                return;
            }

            matrix[row, col] = 'x';
            bool isAdded = false;
            if (row > 0 || col > 0)
            {
                path.Add(direction);
                isAdded = true;
            }
            
            FindExit(row, col + 1, matrix, 'R');
            FindExit(row + 1, col, matrix, 'D');
            FindExit(row, col - 1, matrix, 'L');
            FindExit(row - 1, col, matrix, 'U');

            matrix[row, col] = ' ';
            if (isAdded)
            {
                path.RemoveAt(path.Count - 1);
            }          
        }
    }
}