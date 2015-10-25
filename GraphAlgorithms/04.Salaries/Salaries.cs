namespace _04.Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Salaries
    {
        private static List<int>[] graph; 

        private static Dictionary<int, decimal> salary = new Dictionary<int, decimal>();  

        private static void Main()
        {
            int employeesCount = int.Parse(Console.ReadLine());

            graph = new List<int>[employeesCount];
            var hasParents = new bool[employeesCount];

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
                string input = Console.ReadLine();

                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == 'Y')
                    {
                        graph[i].Add(j);
                        hasParents[j] = true;
                    }
                }
            }

            for (int i = 0; i < employeesCount; i++)
            {
                if (!hasParents[i])
                {
                    DFSTraversal(i);
                }               
            }

            Console.WriteLine(salary.Values.Sum());
        }

        private static void DFSTraversal(int node)
        {
            if (!salary.ContainsKey(node))
            {
                salary.Add(node, 0);

                if (graph[node].Count > 0)
                {
                    foreach (var child in graph[node])
                    {
                        DFSTraversal(child);
                        salary[node] += salary[child];
                    }
                }
                else
                {
                    salary[node]++;
                }
            }
        }
    }
}