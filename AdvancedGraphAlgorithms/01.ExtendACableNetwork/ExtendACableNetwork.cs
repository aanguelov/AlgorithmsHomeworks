namespace _01.ExtendACableNetwork
{
    using System;
    using System.Collections.Generic;

    internal class ExtendACableNetwork
    {
        private static List<Edge> edges = new List<Edge>();

        private static bool[] connectedNodes;

        private static void Main()
        {
            int budget = int.Parse(Console.ReadLine().Split(' ')[1]);
            int nodes = int.Parse(Console.ReadLine().Split(' ')[1]);
            int edgesCount = int.Parse(Console.ReadLine().Split(' ')[1]);

            connectedNodes = new bool[nodes];      
            FillEdges(edgesCount);

            edges.Sort();

            int totalWeight = 0;
            foreach (var edge in edges)
            {
                int currentWeight = edge.Weight;
                if ((!connectedNodes[edge.StartNode] && !connectedNodes[edge.EndNode])
                    || (connectedNodes[edge.StartNode] ^ connectedNodes[edge.EndNode]))
                {
                    connectedNodes[edge.StartNode] = true;
                    connectedNodes[edge.EndNode] = true;
                    totalWeight += currentWeight;
                    if (totalWeight > budget)
                    {
                        totalWeight -= currentWeight;                      
                        break;
                    }

                    Console.WriteLine(edge);
                }
            }

            Console.WriteLine("Budget used: " + totalWeight);
        }

        private static void FillEdges(int edgesCount)
        {
            for (int i = 0; i < edgesCount; i++)
            {
                string[] inputLine = Console.ReadLine().Split(' ');
                int startNode = int.Parse(inputLine[0]);
                int endNode = int.Parse(inputLine[1]);
                int weight = int.Parse(inputLine[2]);

                edges.Add(new Edge(startNode, endNode, weight));

                if (inputLine.Length > 3)
                {
                    connectedNodes[startNode] = true;
                    connectedNodes[endNode] = true;
                }
            }
        }

        static Dictionary<int, List<Edge>> BuildGraph()
        {
            var graph = new Dictionary<int, List<Edge>>();
            foreach (var edge in edges)
            {
                if (!graph.ContainsKey(edge.StartNode))
                {
                    graph.Add(edge.StartNode, new List<Edge>());
                }
                graph[edge.StartNode].Add(edge);
                if (!graph.ContainsKey(edge.EndNode))
                {
                    graph.Add(edge.EndNode, new List<Edge>());
                }
                graph[edge.EndNode].Add(edge);
            }

            return graph;
        }
    }
}