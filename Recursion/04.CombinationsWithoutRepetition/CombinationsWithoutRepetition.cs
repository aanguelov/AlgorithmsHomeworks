namespace _04.CombinationsWithoutRepetition
{
    using System;

    internal class CombinationsWithoutRepetition
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] arr = new int[k];

            GenerateCombinations(arr, 0, 1, n);
        }

        private static void GenerateCombinations(int[] arr, int index, int startNum, int endNum)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine("(" + string.Join(" ", arr) + ")");
            }
            else
            {
                for (int i = startNum; i <= endNum; i++)
                {
                    arr[index] = i;
                    startNum = i + 1;
                    GenerateCombinations(arr, index + 1, startNum, endNum);
                }
            }
        }
    }
}