namespace _03.CyclesInAGraph
{
    using System;
    using System.Collections.Generic;

    internal class CyclesInAGraph
    {
        private static void Main()
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != string.Empty)
            {
                string node1 = input.Substring(0, 1);
                string node2 = input.Substring(input.Length - 1);

                if (!graph.ContainsKey(node1))
                {
                    graph.Add(node1, new List<string>());                  
                }

                graph[node1].Add(node2);

                if (!graph.ContainsKey(node2))
                {
                    graph.Add(node2, new List<string>());
                }

                graph[node2].Add(node1);

                input = Console.ReadLine();
            }

            Dictionary<string, int> predecessors = new Dictionary<string, int>();

            foreach (var key in graph.Keys)
            {
                if (!predecessors.ContainsKey(key))
                {
                    predecessors.Add(key, 0);
                }

                foreach (var child in graph[key])
                {
                    if (!predecessors.ContainsKey(child))
                    {
                        predecessors.Add(child, 0);
                    }

                    predecessors[child]++;
                }
            }

            bool[] isRemoved = new bool[graph.Count];
            List<string> removedNodes = new List<string>();
            bool nodeRemoved = true;

            while (nodeRemoved)
            {
                nodeRemoved = false;
                foreach (var key in predecessors.Keys)
                {
                    if (predecessors[key] <= 1)
                    {
                        foreach (var child in graph[key])
                        {
                            if (predecessors.ContainsKey(child))
                            {
                                predecessors[child]--;
                            }
                        }

                        predecessors.Remove(key);
                        removedNodes.Add(key);
                        nodeRemoved = true;
                        break;
                    }
                }
            }

            if (removedNodes.Count == graph.Count)
            {
                Console.WriteLine("Acyclic: Yes");
            }
            else
            {
                Console.WriteLine("Acyclic: No");
            }
        }
    }
}