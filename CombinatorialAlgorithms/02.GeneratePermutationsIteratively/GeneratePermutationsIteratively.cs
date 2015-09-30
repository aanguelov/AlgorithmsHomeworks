namespace _02.GeneratePermutationsIteratively
{
    using System;
    using System.Linq;

    internal class GeneratePermutationsIteratively
    {
        private static int numberOfPermutations = 1;

        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = Enumerable.Range(1, n).ToArray();
            int[] controlArr = new int[n];
            int i = 1;

            while (i < n)
            {
                if (controlArr[i] < i)
                {
                    Console.WriteLine(string.Join(", ", arr));

                    int j = i % 2 != 0 ? controlArr[i] : 0;

                    int temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;

                    numberOfPermutations++;

                    controlArr[i]++;
                    i = 1;
                }
                else if (controlArr[i] == i)
                {
                    controlArr[i] = 0;
                    i++;
                }
            }

            Console.WriteLine(string.Join(", ", arr));
            Console.WriteLine("Total permutations: " + numberOfPermutations);
        }
    }
}