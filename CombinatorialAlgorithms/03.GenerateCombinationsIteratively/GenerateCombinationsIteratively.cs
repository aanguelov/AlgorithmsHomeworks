namespace _03.GenerateCombinationsIteratively
{
    using System;
    using System.Collections.Generic;

    internal class GenerateCombinationsIteratively
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            foreach (int[] combination in GetCombinations(n, k))
            {
                Console.WriteLine(string.Join(", ", combination));
            }
        }

        private static IEnumerable<int[]> GetCombinations(int n, int k)
        {
            int[] result = new int[k];
            Stack<int> numbers = new Stack<int>();
            numbers.Push(1);

            while (numbers.Count > 0)
            {
                int index = numbers.Count - 1;
                int numValue = numbers.Pop();

                while (numValue <= n)
                {
                    result[index] = numValue;
                    index++;
                    numValue++;
                    
                    numbers.Push(numValue);

                    if (index == k)
                    {
                        yield return result;
                        break;
                    }
                }
            }
        } 
    }
}