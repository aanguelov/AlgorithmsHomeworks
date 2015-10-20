namespace _02.AreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class AreasInMatrix
    {
        private static bool[,] visited;

        private static void Main()
        {
            string matrixRows = Console.ReadLine();
            int rows = int.Parse(matrixRows.Substring(matrixRows.Length - 1));
            
            char[][] matrix = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            visited = new bool[rows, matrix[0].Length];
            var result = new Dictionary<char, int>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (!visited[row, col])
                    {
                        if (!result.ContainsKey(matrix[row][col]))
                        {
                            result[matrix[row][col]] = 1;
                        }
                        else
                        {
                            result[matrix[row][col]]++;
                        }                       
                    }

                    FindConnectedAreas(row, col, matrix[row][col], matrix);
                }
            }

            Console.WriteLine("Areas: " + result.Values.Sum());
            foreach (var pair in result)
            {
                Console.WriteLine("Letter '{0}' -> {1}", pair.Key, pair.Value);
            }
        }

        private static void FindConnectedAreas(int row, int col, char ch, char[][] matrix)
        {
            if (row < 0 || col < 0 || row > matrix.GetLength(0) - 1 || col > matrix[row].Length - 1)
            {
                return;
            }

            if (visited[row, col] || matrix[row][col] != ch)
            {
                return;
            }

            visited[row, col] = true;

            FindConnectedAreas(row + 1, col, ch, matrix); // go south
            FindConnectedAreas(row, col + 1, ch, matrix); // go east
            FindConnectedAreas(row - 1, col, ch, matrix); // go north
            FindConnectedAreas(row, col - 1, ch, matrix); // go west
        }
    }
}