namespace _02.NestedLoopsToRecursion
{
    using System;

    internal class NestedLoopsToRecursion
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            PrintNVariables(numbers, 0, 1, n);
        }

        private static void PrintNVariables(int[] arr, int index, int start, int end)
        {
            if (index >= arr.Length)
            {
                PrintArr(arr);
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    arr[index] = i;
                    start = i > 1 ? 1 : i;

                    PrintNVariables(arr, index + 1, start, end);
                }
            }
        }

        private static void PrintArr(int[] arr)
        {
            foreach (var number in arr)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}