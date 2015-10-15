namespace _07.ConnectingCables
{
    using System;
    using System.Collections.Generic;

    internal class ConnectingCables
    {
        private static readonly int[] Side1 = { 1, 2, 3, 4, 5 };

        private static readonly int[] Side2 = { 5, 1, 3, 4, 2 };

        private static readonly int[,] Cables = new int[Side1.Length, Side2.Length];

        private static void Main()
        {
            for (int row = 0; row < Cables.GetLength(0); row++)
            {
                for (int col = 0; col < Cables.GetLength(1); col++)
                {
                    Cables[row, col] = -1;
                }
            }

            int connections = CalculateConnections(Side1.Length - 1, Side2.Length - 1);
            Console.WriteLine("Maximum pairs connected: " + connections);

            int[] connectedCables = GetConnections(Side1.Length - 1, Side2.Length - 1);
            Console.WriteLine("Connected pairs: " + string.Join(" ", connectedCables));
        }

        private static int CalculateConnections(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return 0;
            }

            if (Cables[x, y] == -1)
            {
                int upper = CalculateConnections(x - 1, y);
                int lefter = CalculateConnections(x, y - 1);

                Cables[x, y] = Math.Max(upper, lefter);

                if (Side1[x] == Side2[y])
                {
                    int upperAndLefter = 1 + CalculateConnections(x - 1, y - 1);
                    Cables[x, y] = Math.Max(Cables[x, y], upperAndLefter);
                }
            }

            return Cables[x, y];
        }

        private static int[] GetConnections(int x, int y)
        {
            List<int> temp = new List<int>();

            while (x >= 0 && y >= 0)
            {
                if (Side1[x] == Side2[y] && (CalculateConnections(x - 1, y - 1) + 1) == Cables[x, y])
                {
                    temp.Add(Side1[x]);
                    x--;
                    y--;
                }
                else if (CalculateConnections(x - 1, y) == Cables[x, y])
                {
                    x--;
                }
                else
                {
                    y--;
                }
            }

            temp.Reverse();
            return temp.ToArray();
        }
    }
}