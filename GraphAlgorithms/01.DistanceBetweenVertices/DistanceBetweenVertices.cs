namespace _01.DistanceBetweenVertices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class DistanceBetweenVertices
    {
        private static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>(); 

        private static int minDistance = int.MaxValue;

        private static bool hasChildren = false;

        private static void Main()
        {
            string graphName = Console.ReadLine();
            string inputLine = Console.ReadLine();

            while (inputLine != "Distances to find:")
            {
                int[] inputArgs =
                    inputLine.Split(new[] { '-', '>', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                int vertex = inputArgs[0];

                if (!graph.ContainsKey(vertex))
                {
                    graph[vertex] = new List<int>();
                    for (int i = 1; i < inputArgs.Length; i++)
                    {
                        graph[vertex].Add(inputArgs[i]);
                    }
                }

                inputLine = Console.ReadLine();
            }

            string distance = Console.ReadLine();

            while (distance != string.Empty)
            {
                int startPoint = distance.Split('-').Select(int.Parse).ToArray()[0];
                int endPoint = distance.Split('-').Select(int.Parse).ToArray()[1];

                List<int> visited = new List<int>();
                FindPathsDFS(startPoint, endPoint, visited, new List<int>());
                if (minDistance == int.MaxValue)
                {
                    Console.WriteLine("{0} -> {1}", distance, -1);
                }
                else
                {
                    Console.WriteLine("{0} -> {1}", distance, minDistance);
                    minDistance = int.MaxValue;
                }

                distance = Console.ReadLine();
            }
        }

        private static void FindPathsDFS(int startVertex, int endVertex, List<int> visited, List<int> path)
        {
            if (startVertex == endVertex)
            {
                if (path.Count < minDistance)
                {
                    minDistance = path.Count;
                    return;
                }
            }

            if (!visited.Contains(startVertex))
            {
                visited.Add(startVertex);
                foreach (var child in graph[startVertex])
                {
                    if (!visited.Contains(child))
                    {
                        path.Add(child);
                        FindPathsDFS(child, endVertex, visited, path);
                        path.Remove(child);
                        visited.Remove(child);
                    }
                }
            }
        }
    }
}