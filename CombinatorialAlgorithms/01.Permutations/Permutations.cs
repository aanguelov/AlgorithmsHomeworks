namespace _01.Permutations
{
    using System;
    using System.Linq;

    internal class Permutations
    {
        private static int numberOfPermutations;

        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = Enumerable.Range(1, n).ToArray();
            Permute(arr, 0);
            Console.WriteLine("Total permutations: " + numberOfPermutations);
        }

        private static void Permute(int[] array, int startIndex)
        {
            if (startIndex >= array.Length)
            {
                Console.WriteLine(string.Join(", ", array));
                numberOfPermutations++;
            }
            else
            {
                for (int i = startIndex; i < array.Length; i++)
                {
                    int temp = array[i];
                    array[i] = array[startIndex];
                    array[startIndex] = temp;

                    Permute(array, startIndex + 1);

                    int tempSecond = array[i];
                    array[i] = array[startIndex];
                    array[startIndex] = tempSecond;
                }
            }
        }
    }
}